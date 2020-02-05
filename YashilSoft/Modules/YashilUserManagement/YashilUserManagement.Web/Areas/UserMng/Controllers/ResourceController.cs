	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class ResourceController : BaseController<Resource ,int,ResourceListViewModel,  ResourceEditModel,ResourceSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IResourceService _resourceService;
        public ResourceController(IResourceService resourceService, IMapper mapper) : base(resourceService, mapper)
        {
            _mapper=mapper;
            _resourceService=resourceService;
        }
    }
}      