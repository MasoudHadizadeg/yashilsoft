	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using  YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
	public class EducationalCenterController : BaseController<EducationalCenter ,int,EducationalCenterListViewModel, EducationalCenterEditModel,EducationalCenterSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IEducationalCenterService _educationalCenterService;
        public EducationalCenterController(IEducationalCenterService educationalCenterService, IMapper mapper) : base(educationalCenterService, mapper)
        {
            _mapper=mapper;
            _educationalCenterService=educationalCenterService;
        }
    }
}      