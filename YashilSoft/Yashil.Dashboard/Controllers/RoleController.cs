using AutoMapper;
using Yashil.Core.Interfaces;
using Yashil.Core.Interfaces.Data;
using Yashil.Dashboard.Web.BaseClasses;
using Yashil.Dashboard.Web.Data;
using Yashil.Dashboard.Web.ViewModels;

namespace Yashil.Dashboard.Web.Controllers
{
    /// <summary>
    /// Represents a Role.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	public class RoleController : BaseController<Role ,int, RoleViewModel, RoleEditModel>
    
    {
	   public RoleController(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, unitOfWork.GetRoleRepository(),mapper)
        {
        }
    }
}      