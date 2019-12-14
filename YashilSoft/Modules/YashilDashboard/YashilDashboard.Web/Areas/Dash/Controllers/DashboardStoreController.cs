	 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDashboard.Core.Services;
using  YashilDashboard.Web.Areas.Dash.ViewModels;

namespace YashilDashboard.Web.Areas.Dash.Controllers
{
	public class DashboardStoreController : BaseController<DashboardStore ,int,DashboardStoreListViewModel, DashboardStoreViewModel, DashboardStoreEditModel,DashboardStoreSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IDashboardStoreService _dashboardStoreService;
        public DashboardStoreController(IDashboardStoreService dashboardStoreService, IMapper mapper) : base(dashboardStoreService, mapper)
        {
            _mapper=mapper;
            _dashboardStoreService=dashboardStoreService;
        }


        [HttpGet("GetDashboardDesigner")]
        public JsonResult GetDashboardDesigner(int id)
        {
            string dashboardStr = _dashboardStoreService.GetDashboardDesigner(id);
            if (!string.IsNullOrEmpty(dashboardStr))
            {
                return new JsonResult(dashboardStr);
            }

            return null;
        }

        [HttpGet("GetDashboardViewer")]
        public JsonResult GetDashboardViewer(int id)
        {
            string DashboardStr = _dashboardStoreService.GetDashboardViewer(id);
            if (!string.IsNullOrEmpty(DashboardStr))
            {
                return new JsonResult(DashboardStr);
            }

            return null;
        }

//        [HttpPost("SaveDashboardDesign")]
//        public async Task<bool> SaveDashboardDesign(DashboardFileViewModel data)
//        {
////            var Dashboard = new StiDashboard();
////            Dashboard.LoadFromString(data.DashboardFile);
////            var DashboardStore = new DashboardStore
////            {
////                Id = data.DashboardId,
////                ModifyBy = CurrentUserId,
////                ModificationDate = DateTime.Now,
////                DashboardFile = Dashboard.SaveToByteArray()
////            };
////            await _dashboardStoreService.UpdateAsync(DashboardStore, data.DashboardId, new List<string> { "DashboardFile" }, true);
//            return true;
//        }

        [HttpPost("Handler")]
        public IActionResult Handler([FromBody] string command)
        {
            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};

            //var commandObject = JsonSerializer.Deserialize<CommandJson>(command, options);
            //return new ObjectResult(_dashboardStoreService.HandleDashboard(commandObject));
            return null;
        }

        protected override void CustomMapBeforeInsert(DashboardStoreEditModel editModel, DashboardStore entity)
        {
            foreach (var connectionStringId in editModel.ConnectionStringIds)
            {
                entity.DashboardConnectionString.Add(new DashboardConnectionString
                {
                    ConnectionStringId = Convert.ToInt32(connectionStringId),
                    DashboardId = editModel.Id,
                    CreateBy = CurrentUserId.Value,
                    CreationDate = DateTime.Now
                });
            }
        }


        protected override async Task UpdateAsync(DashboardStore entity, DashboardStoreEditModel editModel, int entityId,
            List<string> notModifiedProperties)
        {
            var dashboardConnectionStrings = editModel.ConnectionStringIds.Select(conStringId =>
                new DashboardConnectionString
                {
                    ConnectionStringId = Convert.ToInt32(conStringId),
                    DashboardId = editModel.Id,
                    CreateBy = CurrentUserId.Value,
                    CreationDate = DateTime.Now
                }).ToList();

            await _dashboardStoreService.UpdateDashboardStoreWithConnectionStringAsync(entity, dashboardConnectionStrings,
                GetModifiedProperties(entity));
        }


//        protected override async Task<DashboardStoreEditModel> GetEntityForEdit(int id)
//        {
//            var dashboardStore = await _dashboardStoreService.GetEntityForEdit(id);
//            return _mapper.Map<DashboardStore, DashboardStoreEditModel>(dashboardStore);
//        }
    }
}      