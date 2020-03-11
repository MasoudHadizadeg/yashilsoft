	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using  YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
	public class AdditionalUserPropController : BaseController<AdditionalUserProp ,int,AdditionalUserPropListViewModel, AdditionalUserPropEditModel,AdditionalUserPropSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAdditionalUserPropService _additionalUserPropService;
        public AdditionalUserPropController(IAdditionalUserPropService additionalUserPropService, IMapper mapper) : base(additionalUserPropService, mapper)
        {
            _mapper=mapper;
            _additionalUserPropService=additionalUserPropService;
        }
    }
}      