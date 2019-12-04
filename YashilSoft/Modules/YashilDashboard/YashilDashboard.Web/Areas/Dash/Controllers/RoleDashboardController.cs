	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDashboard.Core.Services;
using  YashilDashboard.Web.Areas.Dash.ViewModels;

namespace YashilDashboard.Web.Areas.Dash.Controllers
{
	public class RoleDashboardController : BaseController<RoleDashboard ,int,RoleDashboardListViewModel, RoleDashboardViewModel, RoleDashboardEditModel,RoleDashboardSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRoleDashboardService _roleDashboardService;
        public RoleDashboardController(IRoleDashboardService roleDashboardService, IMapper mapper) : base(roleDashboardService, mapper)
        {
            _mapper=mapper;
            _roleDashboardService=roleDashboardService;
        }
    }
}      