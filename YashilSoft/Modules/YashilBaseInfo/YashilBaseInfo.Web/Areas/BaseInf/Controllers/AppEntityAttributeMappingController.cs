	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using  YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf.Controllers
{
	public class AppEntityAttributeMappingController : BaseController<AppEntityAttributeMapping ,int,AppEntityAttributeMappingListViewModel, AppEntityAttributeMappingEditModel,AppEntityAttributeMappingSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppEntityAttributeMappingService _appEntityAttributeMappingService;
        public AppEntityAttributeMappingController(IAppEntityAttributeMappingService appEntityAttributeMappingService, IMapper mapper) : base(appEntityAttributeMappingService, mapper)
        {
            _mapper=mapper;
            _appEntityAttributeMappingService=appEntityAttributeMappingService;
        }
    }
}      