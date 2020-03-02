	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using  YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf.Controllers
{
	public class CommonBaseTypeController : BaseController<CommonBaseType ,int,CommonBaseTypeListViewModel, CommonBaseTypeEditModel,CommonBaseTypeSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICommonBaseTypeService _commonBaseTypeService;
        public CommonBaseTypeController(ICommonBaseTypeService commonBaseTypeService, IMapper mapper) : base(commonBaseTypeService, mapper)
        {
            _mapper=mapper;
            _commonBaseTypeService=commonBaseTypeService;
        }
    }
}      