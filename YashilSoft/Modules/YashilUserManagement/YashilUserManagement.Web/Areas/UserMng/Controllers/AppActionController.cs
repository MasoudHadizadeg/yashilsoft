	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class AppActionController : BaseController<AppAction ,int,AppActionListViewModel, AppActionViewModel, AppActionEditModel,AppActionSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppActionService _appActionService;
        public AppActionController(IAppActionService appActionService, IMapper mapper) : base(appActionService, mapper)
        {
            _mapper=mapper;
            _appActionService=appActionService;
        }
    }
}      