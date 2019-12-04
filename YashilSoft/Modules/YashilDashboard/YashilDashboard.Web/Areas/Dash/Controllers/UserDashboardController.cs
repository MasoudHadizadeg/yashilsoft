	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDashboard.Core.Services;
using  YashilDashboard.Web.Areas.Dash.ViewModels;

namespace YashilDashboard.Web.Areas.Dash.Controllers
{
	public class UserDashboardController : BaseController<UserDashboard ,int,UserDashboardListViewModel, UserDashboardViewModel, UserDashboardEditModel,UserDashboardSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserDashboardService _userDashboardService;
        public UserDashboardController(IUserDashboardService userDashboardService, IMapper mapper) : base(userDashboardService, mapper)
        {
            _mapper=mapper;
            _userDashboardService=userDashboardService;
        }
    }
}      