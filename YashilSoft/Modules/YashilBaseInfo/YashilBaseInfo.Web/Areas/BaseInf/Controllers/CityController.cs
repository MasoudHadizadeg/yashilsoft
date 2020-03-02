	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using  YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf.Controllers
{
	public class CityController : BaseController<City ,int,CityListViewModel, CityEditModel,CitySimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICityService _cityService;
        public CityController(ICityService cityService, IMapper mapper) : base(cityService, mapper)
        {
            _mapper=mapper;
            _cityService=cityService;
        }
    }
}      