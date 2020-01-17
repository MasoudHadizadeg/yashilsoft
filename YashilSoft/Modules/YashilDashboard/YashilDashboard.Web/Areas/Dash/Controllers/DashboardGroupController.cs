using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDashboard.Core.Services;
using YashilDashboard.Web.Areas.Dash.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace YashilDashboard.Web.Areas.Dash.Controllers
{
    public class DashboardGroupController : BaseController<DashboardGroup, int, DashboardGroupListViewModel,
        DashboardGroupViewModel, DashboardGroupEditModel, DashboardGroupSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IDashboardGroupService _dashboardGroupService;

        public DashboardGroupController(IDashboardGroupService dashboardGroupService, IMapper mapper) : base(
            dashboardGroupService, mapper)
        {
            _mapper = mapper;
            _dashboardGroupService = dashboardGroupService;
        }

        [HttpGet("GetDashboardGroupList")]
        public async Task<List<DashboardGroupViewModel>> GetDashboardGroupList()
        {
            return await _dashboardGroupService.GetDashboardGroupList()
                .ProjectTo<DashboardGroupViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}