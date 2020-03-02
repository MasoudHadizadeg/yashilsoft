	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using  YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
	public class RepresentationController : BaseController<Representation ,int,RepresentationListViewModel, RepresentationEditModel,RepresentationSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRepresentationService _representationService;
        public RepresentationController(IRepresentationService representationService, IMapper mapper) : base(representationService, mapper)
        {
            _mapper=mapper;
            _representationService=representationService;
        }
    }
}      