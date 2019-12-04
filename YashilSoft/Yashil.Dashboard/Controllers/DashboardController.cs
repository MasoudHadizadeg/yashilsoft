using AutoMapper;
using Yashil.Core.Interfaces;
using Yashil.Core.Interfaces.Data;
using Yashil.Dashboard.Web.BaseClasses;
using Yashil.Dashboard.Web.Data;
using Yashil.Dashboard.Web.ViewModels;

namespace Yashil.Dashboard.Web.Controllers
{
    /// <summary>
    /// Represents a Dashboard.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	public class DashboardController : BaseController<Dashboard ,int, DashboardViewModel, DashboardEditModel>
    
    {
	   public DashboardController(IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, unitOfWork.GetDashboardRepository(),mapper)
        {
        }
    }
}      