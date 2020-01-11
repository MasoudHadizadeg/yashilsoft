using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly ClaimsPrincipal _claimsPrincipal;
        public ReportStoreService(IUnitOfWork unitOfWork, IReportStoreRepository reportStoreRepository,
            IWebHostEnvironment webHostEnvironment, IYashilConnectionStringService yashilConnectionStringService,
            IReportConnectionStringService reportConnectionStringService, ClaimsPrincipal claimsPrincipal) :
            base(unitOfWork, reportStoreRepository)
        {
            _unitOfWork = unitOfWork;
            _reportStoreRepository = reportStoreRepository;
            _connectionStringService = yashilConnectionStringService;
            _reportConnectionStringService = reportConnectionStringService;
            _claimsPrincipal = claimsPrincipal;
        }

        public string GetReportDesigner(int reportId)
        {
            var report = new StiReport();
            var reportStore = _reportStoreRepository.Get(reportId, true);
            report.Load(reportStore.ReportFile);
            return report.SaveToJsonString();
        }

        public string GetReportViewer(int reportId)
        {
            var report = new StiReport();
            var reportStore = _reportStoreRepository.Get(reportId, true);
            report.Load(reportStore.ReportFile);

            var reportConnectionStrings = _connectionStringService.GetByReportId(reportId).Select(x =>
                new { x.Title, x.ConnectionString, DataProviderTitle = x.DataProvider.Title }).ToList();
            foreach (StiDatabase db in report.Dictionary.Databases)
            {
                // TODO: Add Common Databases
                var connection = reportConnectionStrings.Find(x => x.Title == db.Name);
                if (connection.DataProviderTitle == "MS SQL")
                {
                    ((StiSqlDatabase)db).ConnectionString = connection.ConnectionString;
                }
            }

            report.Render();
            return report.SaveDocumentJsonToString();
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
            var reportStore = Get(reportId);
            var report = new StiReport();
            report.Load(reportStore.ReportFile);

            var connectionStrings =
                _connectionStringService.FindByIds(reportConnectionStrings.Select(x => x.ConnectionStringId));

            report.Dictionary.Databases.Clear();


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
            DeleteContentionStrings(entity.Id);
            var report = AddConnectionStringToReport(entity.Id, reportConnectionStrings);
            entity.ReportFile = report.SaveToByteArray();
            await UpdateAsync(entity, entity.Id, notModifiedProperties, true);
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

        public IQueryable<ReportStore> GetReportList()
        {
            var currentUserId = Convert.ToInt32(this._claimsPrincipal.Identity.Name);
            return _reportStoreRepository.GetUserReportList(currentUserId);
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
        /// Add Predefined Connection String NAME ONLY To Report Databases
        /// DO NOT Set Connection String In Report For Security Reason
        /// </summary>
        /// <param name="report"></param>
        /// <param name="connection"></param>
        private void AddDatabaseToReport(StiReport report, YashilConnectionString connection)
        {
            if (connection.DataProvider.Title == "MS SQL")
            {
                report.Dictionary.Databases.Add(
                    new StiSqlDatabase(connection.Title, connection.Title, connection.Title));
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