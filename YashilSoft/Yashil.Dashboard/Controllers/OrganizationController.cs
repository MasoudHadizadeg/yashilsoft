using AutoMapper;
using Yashil.Core.Interfaces;
using Yashil.Core.Interfaces.Data;
using Yashil.Dashboard.Web.BaseClasses;
using Yashil.Dashboard.Web.Data;
using Yashil.Dashboard.Web.ViewModels;

namespace Yashil.Dashboard.Web.Controllers
{
    /// <summary>
    /// Represents a Organization.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	public class OrganizationController : BaseController<Organization ,int, OrganizationViewModel, OrganizationEditModel>
    
    {
	   public OrganizationController(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, unitOfWork.GetOrganizationRepository(),mapper)
        {
        }
    }
}      