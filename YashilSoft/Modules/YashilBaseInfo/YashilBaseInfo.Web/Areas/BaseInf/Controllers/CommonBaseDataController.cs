	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using  YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf.Controllers
{
	public class CommonBaseDataController : BaseController<CommonBaseData ,int,CommonBaseDataListViewModel, CommonBaseDataEditModel,CommonBaseDataSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICommonBaseDataService _commonBaseDataService;
        public CommonBaseDataController(ICommonBaseDataService commonBaseDataService, IMapper mapper) : base(commonBaseDataService, mapper)
        {
            _mapper=mapper;
            _commonBaseDataService=commonBaseDataService;
        }
    }
}      