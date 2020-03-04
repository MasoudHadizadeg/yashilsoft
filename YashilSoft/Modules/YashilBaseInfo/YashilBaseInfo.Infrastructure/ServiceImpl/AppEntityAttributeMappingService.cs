	using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
	public class AppEntityAttributeMappingService : GenericService<AppEntityAttributeMapping,int>, IAppEntityAttributeMappingService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IAppEntityAttributeMappingRepository _appEntityAttributeMappingRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public AppEntityAttributeMappingService (IUnitOfWork unitOfWork, IAppEntityAttributeMappingRepository appEntityAttributeMappingRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, appEntityAttributeMappingRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_appEntityAttributeMappingRepository = appEntityAttributeMappingRepository;
			_userPrincipal = userPrincipal;
        }
			  public string GetDefaultValue(int id)
				{
					return _appEntityAttributeMappingRepository.GetDefaultValue(id);
				}	
			  public string GetAllowedValues(int id)
				{
					return _appEntityAttributeMappingRepository.GetAllowedValues(id);
				}	
			  public string GetDescription(int id)
				{
					return _appEntityAttributeMappingRepository.GetDescription(id);
				}	
	
    }
}      
 