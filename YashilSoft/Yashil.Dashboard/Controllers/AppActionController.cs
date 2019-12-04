using AutoMapper;
using Yashil.Dashboard.Web.BaseClasses;
using Yashil.Core.Entities;
using Yashil.Core.Interfaces;
using Yashil.Core.Interfaces.Data;
using Yashil.Dashboard.Web.Data;
using Yashil.Dashboard.Web.ViewModels;

namespace Yashil.Dashboard.Web.Controllers
{
    /// <summary>
    /// Represents a AppAction.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	public class AppActionController : BaseController<AppAction, int, AppActionViewModel, AppActionEditModel>

    {
        public AppActionController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, unitOfWork.GetAppActionRepository(), mapper)
        {
        }
    }
}