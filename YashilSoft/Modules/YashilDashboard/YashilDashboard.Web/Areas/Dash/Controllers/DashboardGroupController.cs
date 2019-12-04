	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDashboard.Core.Services;
using  YashilDashboard.Web.Areas.Dash.ViewModels;

namespace YashilDashboard.Web.Areas.Dash.Controllers
{
	public class DashboardGroupController : BaseController<DashboardGroup ,int,DashboardGroupListViewModel, DashboardGroupViewModel, DashboardGroupEditModel,DashboardGroupSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IDashboardGroupService _dashboardGroupService;
        public DashboardGroupController(IDashboardGroupService dashboardGroupService, IMapper mapper) : base(dashboardGroupService, mapper)
        {
            _mapper=mapper;
            _dashboardGroupService=dashboardGroupService;
        }
    }
}      