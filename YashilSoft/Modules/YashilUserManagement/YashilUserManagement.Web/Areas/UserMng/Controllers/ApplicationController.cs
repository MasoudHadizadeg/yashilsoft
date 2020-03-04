	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class ApplicationController : BaseController<Application ,int,ApplicationListViewModel, ApplicationEditModel,ApplicationSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationService _applicationService;
        public ApplicationController(IApplicationService applicationService, IMapper mapper) : base(applicationService, mapper)
        {
            _mapper=mapper;
            _applicationService=applicationService;
        }
    }
}      