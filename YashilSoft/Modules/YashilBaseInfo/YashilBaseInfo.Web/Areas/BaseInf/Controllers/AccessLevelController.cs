	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using  YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf.Controllers
{
	public class AccessLevelController : BaseController<AccessLevel ,int,AccessLevelListViewModel,  AccessLevelEditModel,AccessLevelSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAccessLevelService _accessLevelService;
        public AccessLevelController(IAccessLevelService accessLevelService, IMapper mapper) : base(accessLevelService, mapper)
        {
            _mapper=mapper;
            _accessLevelService=accessLevelService;
        }
    }
}      