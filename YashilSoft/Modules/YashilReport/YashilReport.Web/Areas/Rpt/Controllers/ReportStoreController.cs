using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilReport.Core;
using YashilReport.Core.Services;
using YashilReport.Infrastructure.ReportClasses.Adapters;
using YashilReport.Web.Areas.Rpt.ViewModels;

namespace YashilReport.Web.Areas.Rpt.Controllers
{
    public class ReportStoreController : BaseController<ReportStore, int, ReportStoreListViewModel, ReportStoreViewModel
        , ReportStoreEditModel, ReportStoreSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IReportStoreService _reportStoreService;
        private readonly IReportConnectionStringService _reportConnectionStringService;

        public ReportStoreController(IReportStoreService reportStoreService,
            IReportConnectionStringService reportConnectionStringService, IMapper mapper,
            IWebHostEnvironment webHostEnvironment) : base(reportStoreService, mapper)
        {
            _mapper = mapper;
            _reportStoreService = reportStoreService;
            _reportConnectionStringService = reportConnectionStringService;
        }


        [HttpGet("GetReportDesigner")]
        public JsonResult GetReportDesigner(int id)
        {
            string reportStr = _reportStoreService.GetReportDesigner(id);
            if (!string.IsNullOrEmpty(reportStr))
            {
                return new JsonResult(reportStr);
            }

            return null;
        }

        [HttpGet("GetReportViewer")]
        public JsonResult GetReportViewer()
        {
//            var report = new StiReport();
//            var path = Path.Combine(ProjectConfiguration.FileRootPath, "Files", @"Reports\Report.mrt");
//            if (System.IO.File.Exists(path))
//            {
//                report.Load(path);
//
//                var dbMsSql = (StiSqlDatabase) report.Dictionary.Databases["TlsConnectionString"];
//                // Set Fake Connection
//                dbMsSql.ConnectionString = "...";
//                // @"Data Source=.;Initial Catalog=TLSDb;Integrated Security=False;Persist Security Info=True;User ID=sa;Password=salam";
//                report.Render();
//                var reportStr = report.SaveDocumentJsonToString();
//                var res = new JsonResult(reportStr);
//                return res;
//            }

            return null;
        }

        [HttpPost("SaveReportDesign")]
        public async Task<bool> SaveReportDesign(ReportFileViewModel data)
        {
            return await _reportStoreService.SaveReportDesign(data.ReportId, data.ReportFile);
        }

        [HttpPost("Handler")]
        public IActionResult Handler([FromBody] string command)
        {
            //CommandJson
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var commandObject = JsonSerializer.Deserialize<CommandJson>(command, options);
            return new ObjectResult(_reportStoreService.HandleReport(commandObject));
        }

        protected override void CustomMapBeforeInsert(ReportStoreEditModel editModel, ReportStore entity)
        {
            CustomMap(editModel, entity);
        }

        protected override Task UpdateAsync(ReportStore entity, int entityId, List<string> notModifiedProperties)
        {
            List<ReportConnectionString> reportConnectionStrings = new List<ReportConnectionString>();
            foreach (var connectionStringId in editModel.ConnectionStringList)
            {
                reportConnectionStrings.Add(new ReportConnectionString
                {
                    ConnectionStringId = Convert.ToInt32(connectionStringId),
                    ReportId = editModel.Id,
                    CreateBy = CurrentUserId.Value,
                    CreationDate = DateTime.Now
                });
            }
            return base.UpdateAsync(entity, entityId, notModifiedProperties);
        }

       

        private void CustomMap(ReportStoreEditModel editModel, ReportStore entity)
        {
            foreach (var connectionStringId in editModel.ConnectionStringList)
            {
                entity.ReportConnectionString.Add(new ReportConnectionString
                {
                    ConnectionStringId = Convert.ToInt32(connectionStringId),
                    ReportId = editModel.Id,
                    CreateBy = CurrentUserId.Value,
                    CreationDate = DateTime.Now
                });
            }
        }

        protected override async Task<ReportStoreEditModel> GetEntityForEdit(int id)
        {
            var reportStore = await _reportStoreService.GetEntityForEdit(id);
            return _mapper.Map<ReportStore, ReportStoreEditModel>(reportStore);
        }
    }
}