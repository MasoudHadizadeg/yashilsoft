	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using  YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf.Controllers
{
	public class YashilDataProviderController : BaseController<YashilDataProvider ,int,YashilDataProviderListViewModel, YashilDataProviderEditModel,YashilDataProviderSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IYashilDataProviderService _yashilDataProviderService;
        public YashilDataProviderController(IYashilDataProviderService yashilDataProviderService, IMapper mapper) : base(yashilDataProviderService, mapper)
        {
            _mapper=mapper;
            _yashilDataProviderService=yashilDataProviderService;
        }
    }
}      