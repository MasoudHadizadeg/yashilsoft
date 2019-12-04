	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class ResourceAppActionController : BaseController<ResourceAppAction ,int,ResourceAppActionListViewModel, ResourceAppActionViewModel, ResourceAppActionEditModel,ResourceAppActionSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IResourceAppActionService _resourceAppActionService;
        public ResourceAppActionController(IResourceAppActionService resourceAppActionService, IMapper mapper) : base(resourceAppActionService, mapper)
        {
            _mapper=mapper;
            _resourceAppActionService=resourceAppActionService;
        }
    }
}      