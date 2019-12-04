using AutoMapper;
using Yashil.Core.Entities;
using Yashil.Core.Interfaces;
using Yashil.Core.Interfaces.Data;
using Yashil.Dashboard.Web.BaseClasses;
using Yashil.Dashboard.Web.Data;
using Yashil.Dashboard.Web.ViewModels;

namespace Yashil.Dashboard.Web.Controllers
{
    /// <summary>
    /// Represents a AccessLevel.
    /// </summary>
	public class AccessLevelController : BaseController<AccessLevel, int, AccessLevelViewModel, AccessLevelEditModel>

    {
        public AccessLevelController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, unitOfWork.GetAccessLevelRepository(), mapper)
        {
        }
    }
}