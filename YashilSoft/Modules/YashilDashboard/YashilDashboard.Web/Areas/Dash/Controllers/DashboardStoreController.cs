	 
using AutoMapper;
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
    }
}      