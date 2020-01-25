			
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
	public class AppActionService : GenericService<AppAction,int>, IAppActionService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IAppActionRepository _appActionRepository;
       
		public AppActionService (IUnitOfWork unitOfWork, IAppActionRepository appActionRepository, IUserPrincipal userPrincipal) : base(unitOfWork, appActionRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_appActionRepository = appActionRepository;
        }
    }
}      
 