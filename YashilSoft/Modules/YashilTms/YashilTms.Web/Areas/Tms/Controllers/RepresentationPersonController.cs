	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using  YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
	public class RepresentationPersonController : BaseController<RepresentationPerson ,int,RepresentationPersonListViewModel, RepresentationPersonEditModel,RepresentationPersonSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRepresentationPersonService _representationPersonService;
        public RepresentationPersonController(IRepresentationPersonService representationPersonService, IMapper mapper) : base(representationPersonService, mapper)
        {
            _mapper=mapper;
            _representationPersonService=representationPersonService;
        }
    }
}      