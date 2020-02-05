	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDashboard.Core.Services;
using  YashilDashboard.Web.Areas.Dash.ViewModels;

namespace YashilDashboard.Web.Areas.Dash.Controllers
{
	public class DashboardConnectionStringController : BaseController<DashboardConnectionString ,int,DashboardConnectionStringListViewModel,  DashboardConnectionStringEditModel,DashboardConnectionStringSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IDashboardConnectionStringService _dashboardConnectionStringService;
        public DashboardConnectionStringController(IDashboardConnectionStringService dashboardConnectionStringService, IMapper mapper) : base(dashboardConnectionStringService, mapper)
        {
            _mapper=mapper;
            _dashboardConnectionStringService=dashboardConnectionStringService;
        }
    }
}      