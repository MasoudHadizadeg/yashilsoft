using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using YashilReport.Core;
using YashilReport.Core.Repositories;
using YashilReport.Core.Services;
using YashilReport.Infrastructure.ReportClasses.Adapters;

namespace YashilReport.Infrastructure.ServiceImpl
{
    public class ReportStoreService : GenericService<ReportStore, int>, IReportStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReportStoreRepository _reportStoreRepository;
        private readonly IYashilConnectionStringService _connectionStringService;
        private readonly IReportConnectionStringService _reportConnectionStringService;

        public ReportStoreService(IUnitOfWork unitOfWork, IReportStoreRepository reportStoreRepository,
            IWebHostEnvironment webHostEnvironment, IYashilConnectionStringService yashilConnectionStringService,
            IReportConnectionStringService reportConnectionStringService) :
            base(unitOfWork, reportStoreRepository)
        {
            _unitOfWork = unitOfWork;
            _reportStoreRepository = reportStoreRepository;
            _connectionStringService = yashilConnectionStringService;
            _reportConnectionStringService = reportConnectionStringService;
        }

        public Task<bool> SaveReportDesign(int dataReportId, string dataReportFile)
        {
            throw new System.NotImplementedException();
        }

        public string GetReportDesigner(int reportId)
        {
            var report = new StiReport();
            var reportStore = _reportStoreRepository.Get(reportId, true);
            report.Load(reportStore.ReportFile);
            return report.SaveToJsonString();
        }

        public void DeleteContentionStrings(int reportId, bool save = false)
        {
            _reportStoreRepository.DeleteContentionStrings(reportId);
        }

        public async Task<ReportStore> GetEntityForEdit(int reportId)
        {
            return await _reportStoreRepository.GetForEditAsync(reportId, true);
        }

        private StiReport AddConnectionStringToReport(int reportId,
            List<ReportConnectionString> reportConnectionStrings)
        {
            DeleteContentionStrings(reportId);
            var reportStore = Get(reportId);
            var report = new StiReport();
            report.Load(reportStore.ReportFile);

            var connectionStrings =
                _connectionStringService.FindByIds(reportConnectionStrings.Select(x => x.ConnectionStringId));

            var deleteDatabases =
                report.Dictionary.Databases.Items.Where(x => !connectionStrings.Select(c => c.Title).Contains(x.Name));
            foreach (var db in deleteDatabases)
            {
                report.Dictionary.Databases.Remove(db);
            }

            foreach (var connectionString in reportConnectionStrings)
            {
                _reportConnectionStringService.Add(connectionString);
            }

            foreach (var connection in connectionStrings)
            {
                AddDatabaseToReport(report, connection);
            }

            return report;
        }

        public async Task UpdateReportStoreWithConnectionStringAsync(ReportStore entity,
            List<ReportConnectionString> reportConnectionStrings,
            List<string> notModifiedProperties)
        {
            var report = AddConnectionStringToReport(entity.Id, reportConnectionStrings);
            entity.ReportFile = report.SaveToByteArray();
            await UpdateAsync(entity, entity.Id, notModifiedProperties,true);
        }

        public Result HandleReport(CommandJson command)
        {
            var connectionString = _connectionStringService.GetConnectionStringByName(command.ConnectionString);
            command.ConnectionString = connectionString;

            //TODO: Add Common Database Types
            if (command.Database == "MS SQL")
                return new MssqlAdapter().Process(command);
            return null;
        }

        public override async Task<ReportStore> AddAsync(ReportStore reportStore, bool saveAfterAdd = false)
        {
            var report = new StiReport();
            var connectionStrings =
                _connectionStringService.FindByIds(
                    reportStore.ReportConnectionString.Select(x => x.ConnectionStringId));
            foreach (var connection in connectionStrings)
            {
                AddDatabaseToReport(report, connection);
            }

            reportStore.ReportFile = report.SaveToByteArray();
            return await base.AddAsync(reportStore, saveAfterAdd);
        }

        /// <summary>
        /// اضافه کردن عناوین مربوط به پایگاه داده های  انتخاب شده به گزارش
        /// متن مربوط به رشته اتصال نباید در گزارش ذخیره شود و موقع اجرای پرس و جو های گزارش  این رشته های اتصال از پایگاه داده خوانده خواهد شد
        /// </summary>
        /// <param name="report">گزارش</param>
        /// <param name="connection">ارتباط</param>
        private void AddDatabaseToReport(StiReport report, YashilConnectionString connection)
        {
            if (connection.DataProvider.Title == "MS SQL")
            {
                report.Dictionary.Databases.Add(new StiSqlDatabase(connection.Title, connection.Title, connection.Title));
            }
            else if (connection.DataProvider.Title == "Postgres")
            {
                report.Dictionary.Databases.Add(new StiPostgreSQLDatabase(connection.Title, connection.Title,
                    connection.Title));
            }
            else if (connection.DataProvider.Title == "MySql")
            {
                report.Dictionary.Databases.Add(new StiMySqlDatabase(connection.Title, connection.Title,
                    connection.Title));
            }
        }
    }
}