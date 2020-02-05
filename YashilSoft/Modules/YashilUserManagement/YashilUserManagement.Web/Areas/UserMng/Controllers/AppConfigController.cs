	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class AppConfigController : BaseController<AppConfig ,int,AppConfigListViewModel,  AppConfigEditModel,AppConfigSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppConfigService _appConfigService;
        public AppConfigController(IAppConfigService appConfigService, IMapper mapper) : base(appConfigService, mapper)
        {
            _mapper=mapper;
            _appConfigService=appConfigService;
        }
    }
}      