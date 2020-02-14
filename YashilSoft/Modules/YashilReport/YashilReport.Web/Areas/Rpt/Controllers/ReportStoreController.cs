using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stimulsoft.Report;
using Yashil.Common.Core.Classes;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.CustomViewModels;
using Yashil.Core.Entities;
using YashilReport.Core;
using YashilReport.Core.Services;
using YashilReport.Web.Areas.Rpt.ViewModels;

namespace YashilReport.Web.Areas.Rpt.Controllers
{
    public class ReportStoreController : BaseController<ReportStore, int, ReportStoreListViewModel, ReportStoreEditModel
        , ReportStoreSimpleViewModel>
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
            await _reportStoreService.UpdateAsync(reportStore, data.ReportId, new List<string> {"ReportFile"}, true,
                true);

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
            List<string> props, bool modifyProps = true)
        {
            var reportConnectionStrings = editModel.ConnectionStringIds.Select(conStringId =>
                new ReportConnectionString
                {
                    ConnectionStringId = Convert.ToInt32(conStringId),
                    ReportId = editModel.Id,
                    CreateBy = CurrentUserId.Value,
                    CreationDate = DateTime.Now
                }).ToList();

            await _reportStoreService.UpdateReportStoreWithConnectionStringAsync(entity, reportConnectionStrings, null);
        }

        protected override async Task<ReportStoreEditModel> GetEntityForEdit(int id)
        {
            var reportStore = await _reportStoreService.GetEntityForEdit(id);
            return _mapper.Map<ReportStore, ReportStoreEditModel>(reportStore);
        }

        [HttpGet("GetReportList")]
        public async Task<List<StoreCustomViewModel>> GetReportList()
        {
            return await _reportStoreService.GetReportList()
                .ProjectTo<StoreCustomViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("GetReportStoresAssignedToReportGroupAsync")]
        public async Task<LoadResult> GetReportStoresAssignedToReportGroupAsync(
            CustomDataSourceLoadOptions loadOptions, int id)
        {
            IQueryable<ReportStore> entities = _reportStoreService.GetReportStoresAssignedToGroupAsync(id);
            return await DataSourceLoader.LoadAsync(
                entities.ProjectTo<ReportStoreSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetReportStoresNotAssignedToReportGroupAsync")]
        public async Task<LoadResult> GetReportStoresNotAssignedToReportGroupAsync(
            CustomDataSourceLoadOptions loadOptions, int id)
        {
            IQueryable<ReportStore> entities = _reportStoreService.GetReportStoresNotAssignedToGroupAsync(id);
            return await DataSourceLoader.LoadAsync(
                entities.ProjectTo<ReportStoreSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpPost("AssignSelectedItemsToReportGroup")]
        public async Task<bool> AssignSelectedItemsToReportGroup(AssignableListEditModel assignableListEditModel)
        {
            return await _reportStoreService.AssignSelectedItemsToReportGroup(
                new List<int>(assignableListEditModel.SelectedItems), assignableListEditModel.GroupId,
                assignableListEditModel.Assign);
        }



        [HttpGet("GetReportStoresAssignedToRoleAsync")]
        public async Task<LoadResult> GetReportStoresAssignedToRoleAsync(
            CustomDataSourceLoadOptions loadOptions, int id)
        {
            IQueryable<ReportStore> entities = _reportStoreService.GetReportStoresAssignedToRoleAsync(id);
            return await DataSourceLoader.LoadAsync(
                entities.ProjectTo<ReportStoreSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetReportStoresNotAssignedToRoleAsync")]
        public async Task<LoadResult> GetReportStoresNotAssignedToRoleAsync(
            CustomDataSourceLoadOptions loadOptions, int id)
        {
            IQueryable<ReportStore> entities = _reportStoreService.GetReportStoresNotAssignedToRoleAsync(id);
            return await DataSourceLoader.LoadAsync(
                entities.ProjectTo<ReportStoreSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpPost("AssignSelectedItemsToRole")]
        public async Task<bool> AssignSelectedItemsToRole(AssignableListEditModel assignableListEditModel)
        {
            return await _reportStoreService.AssignSelectedReportSoresToRole(
                new List<int>(assignableListEditModel.SelectedItems), assignableListEditModel.GroupId,
                assignableListEditModel.Assign);
        }
    }
}