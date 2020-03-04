	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using  YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf.Controllers
{
	public class AppEntityAttributeValueController : BaseController<AppEntityAttributeValue ,int,AppEntityAttributeValueListViewModel, AppEntityAttributeValueEditModel,AppEntityAttributeValueSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppEntityAttributeValueService _appEntityAttributeValueService;
        public AppEntityAttributeValueController(IAppEntityAttributeValueService appEntityAttributeValueService, IMapper mapper) : base(appEntityAttributeValueService, mapper)
        {
            _mapper=mapper;
            _appEntityAttributeValueService=appEntityAttributeValueService;
        }
    }
}      