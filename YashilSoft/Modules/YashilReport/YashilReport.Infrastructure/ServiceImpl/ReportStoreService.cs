using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilReport.Core.Repositories;
using YashilReport.Core.Services;

namespace YashilReport.Infrastructure.ServiceImpl
{
    public class ReportStoreService : GenericService<ReportStore, int>, IReportStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IReportStoreRepository _reportStoreRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ReportStoreService(IUnitOfWork unitOfWork, IReportStoreRepository reportStoreRepository,
            IWebHostEnvironment webHostEnvironment) : base(unitOfWork, reportStoreRepository)
        {
            _unitOfWork = unitOfWork;
            _reportStoreRepository = reportStoreRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public Task<bool> SaveReportDesign(int dataReportId, string dataReportFile)
        {
            throw new System.NotImplementedException();
        }

        public string GetReportDesigner(int reportId)
        {
            var report = new StiReport();
            var reportStore = _reportStoreRepository.Get(reportId, true);
            var stream = new MemoryStream(reportStore.ReportFile);

            report.Load(stream);
            foreach (var dictionaryDatabase in report.Dictionary.Databases)
            {
                if (dictionaryDatabase.GetType() == typeof(StiSqlDatabase))
                {
                    ((StiSqlDatabase) dictionaryDatabase).ConnectionString = "...";
                }
                else if (dictionaryDatabase.GetType() == typeof(StiPostgreSQLDatabase))
                {
                    ((StiPostgreSQLDatabase) dictionaryDatabase).ConnectionString = "...";
                }
            }

            return report.SaveToJsonString();
        }


        public void DeleteContentionString(int reportId, bool save = false)
        {
            _reportStoreRepository.DeleteContentionString(reportId);
        }

        public async Task<ReportStore> GetEntityForEdit(int reportId)
        {
            return await _reportStoreRepository.GetForEditAsync(reportId, true);
        }

        public override async Task<ReportStore> AddAsync(ReportStore reportStore, bool saveAfterAdd = false)
        {
            reportStore.ReportFile = new StiReport().SaveToByteArray();
            return await base.AddAsync(reportStore, saveAfterAdd);
        }

        public override Task<ValueTask<ReportStore>?> UpdateAsync(ReportStore t, object key,
            List<string> modifiedProperties, bool saveAfterUpdate = false)
        {
            return base.UpdateAsync(t, key, modifiedProperties, saveAfterUpdate);
        }
    }
}