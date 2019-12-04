	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class RoleResourceActionController : BaseController<RoleResourceAction ,int,RoleResourceActionListViewModel, RoleResourceActionViewModel, RoleResourceActionEditModel,RoleResourceActionSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRoleResourceActionService _roleResourceActionService;
        public RoleResourceActionController(IRoleResourceActionService roleResourceActionService, IMapper mapper) : base(roleResourceActionService, mapper)
        {
            _mapper=mapper;
            _roleResourceActionService=roleResourceActionService;
        }
    }
}      