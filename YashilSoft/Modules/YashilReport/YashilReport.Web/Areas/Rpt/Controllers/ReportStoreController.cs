using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stimulsoft.Report;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilReport.Core;
using YashilReport.Core.Services;
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
        public JsonResult GetReportViewer(int id)
        {
            string reportStr = _reportStoreService.GetReportViewer(id);
            if (!string.IsNullOrEmpty(reportStr))
            {
                return new JsonResult(reportStr);
            }

            return null;
        }

        [HttpPost("SaveReportDesign")]
        public async Task<bool> SaveReportDesign(ReportFileViewModel data)
        {
            var report = new StiReport();
            report.LoadFromString(data.ReportFile);
            var reportStore = new ReportStore
            {
                Id = data.ReportId,
                ModifyBy = CurrentUserId,
                ModificationDate = DateTime.Now,
                ReportFile = report.SaveToByteArray()
            };
            await _reportStoreService.UpdateAsync(reportStore, data.ReportId, new List<string> {"ReportFile"}, true);
            return true;
        }

        [HttpPost("Handler")]
        public IActionResult Handler([FromBody] string command)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var commandObject = JsonSerializer.Deserialize<CommandJson>(command, options);
            return new ObjectResult(_reportStoreService.HandleReport(commandObject));
        }

        protected override void CustomMapBeforeInsert(ReportStoreEditModel editModel, ReportStore entity)
        {
            foreach (var connectionStringId in editModel.ConnectionStringIds)
            {
                entity.ReportConnectionString.Add(new ReportConnectionString
                {
                    ConnectionStringId = Convert.ToInt32(connectionStringId),
                    CreateBy = CurrentUserId.Value,
                    CreationDate = DateTime.Now
                });
            }
        }

        protected override async Task UpdateAsync(ReportStore entity, ReportStoreEditModel editModel, int entityId,
            List<string> notModifiedProperties)
        {
            var reportConnectionStrings = editModel.ConnectionStringIds.Select(conStringId =>
                new ReportConnectionString
                {
                    ConnectionStringId = Convert.ToInt32(conStringId),
                    ReportId = editModel.Id,
                    CreateBy = CurrentUserId.Value,
                    CreationDate = DateTime.Now
                }).ToList();

            await _reportStoreService.UpdateReportStoreWithConnectionStringAsync(entity, reportConnectionStrings,
                GetModifiedProperties(entity));
        }

        protected override async Task<ReportStoreEditModel> GetEntityForEdit(int id)
        {
            var reportStore = await _reportStoreService.GetEntityForEdit(id);
            return _mapper.Map<ReportStore, ReportStoreEditModel>(reportStore);
        }

        [HttpGet("GetReportList")]
        public async Task<List<ReportStoreViewModel>> GetReportList()
        {
            return await _reportStoreService.GetReportList()
                .ProjectTo<ReportStoreViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}