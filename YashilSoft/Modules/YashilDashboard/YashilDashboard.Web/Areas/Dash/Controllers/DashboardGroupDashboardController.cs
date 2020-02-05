	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDashboard.Core.Services;
using  YashilDashboard.Web.Areas.Dash.ViewModels;

namespace YashilDashboard.Web.Areas.Dash.Controllers
{
	public class DashboardGroupDashboardController : BaseController<DashboardGroupDashboard ,int,DashboardGroupDashboardListViewModel,  DashboardGroupDashboardEditModel,DashboardGroupDashboardSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IDashboardGroupDashboardService _dashboardGroupDashboardService;
        public DashboardGroupDashboardController(IDashboardGroupDashboardService dashboardGroupDashboardService, IMapper mapper) : base(dashboardGroupDashboardService, mapper)
        {
            _mapper=mapper;
            _dashboardGroupDashboardService=dashboardGroupDashboardService;
        }
    }
}      