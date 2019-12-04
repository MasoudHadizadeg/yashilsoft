			
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
       
		public AppConfigService (IUnitOfWork unitOfWork, IAppConfigRepository appConfigRepository) : base(unitOfWork, appConfigRepository)
        {
			_unitOfWork = unitOfWork;
			_appConfigRepository = appConfigRepository;
        }
    }
}      
 