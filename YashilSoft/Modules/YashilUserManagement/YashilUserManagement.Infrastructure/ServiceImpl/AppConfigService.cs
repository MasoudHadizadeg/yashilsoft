	using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
	public class AppConfigService : GenericService<AppConfig,int>, IAppConfigService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IAppConfigRepository _appConfigRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public AppConfigService (IUnitOfWork unitOfWork, IAppConfigRepository appConfigRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, appConfigRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_appConfigRepository = appConfigRepository;
			_userPrincipal = userPrincipal;
        }
			  public string GetDescription(int id)
				{
					return _appConfigRepository.GetDescription(id);
				}	
	
    }
}      
 