	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class RoleController : BaseController<Role ,int,RoleListViewModel,  RoleEditModel,RoleSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService, IMapper mapper) : base(roleService, mapper)
        {
            _mapper=mapper;
            _roleService=roleService;
        }
    }
}      