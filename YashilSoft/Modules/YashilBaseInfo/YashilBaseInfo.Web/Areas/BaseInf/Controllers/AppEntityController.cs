	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using  YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf.Controllers
{
	public class AppEntityController : BaseController<AppEntity ,int,AppEntityListViewModel, AppEntityEditModel,AppEntitySimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppEntityService _appEntityService;
        public AppEntityController(IAppEntityService appEntityService, IMapper mapper) : base(appEntityService, mapper)
        {
            _mapper=mapper;
            _appEntityService=appEntityService;
        }
    }
}      