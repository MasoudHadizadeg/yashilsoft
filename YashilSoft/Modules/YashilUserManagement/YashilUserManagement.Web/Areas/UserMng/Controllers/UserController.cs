	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class UserController : BaseController<User ,int,UserListViewModel, UserViewModel, UserEditModel,UserSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public UserController(IUserService userService, IMapper mapper) : base(userService, mapper)
        {
            _mapper=mapper;
            _userService=userService;
        }
    }
}      