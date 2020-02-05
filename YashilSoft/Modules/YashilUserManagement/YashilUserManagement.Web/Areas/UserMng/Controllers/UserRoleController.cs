	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class UserRoleController : BaseController<UserRole ,int,UserRoleListViewModel,  UserRoleEditModel,UserRoleSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRoleService _userRoleService;
        public UserRoleController(IUserRoleService userRoleService, IMapper mapper) : base(userRoleService, mapper)
        {
            _mapper=mapper;
            _userRoleService=userRoleService;
        }
    }
}      