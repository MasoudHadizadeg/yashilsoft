	using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
	public class AppEntityAttributeValueService : GenericService<AppEntityAttributeValue,int>, IAppEntityAttributeValueService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IAppEntityAttributeValueRepository _appEntityAttributeValueRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public AppEntityAttributeValueService (IUnitOfWork unitOfWork, IAppEntityAttributeValueRepository appEntityAttributeValueRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, appEntityAttributeValueRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_appEntityAttributeValueRepository = appEntityAttributeValueRepository;
			_userPrincipal = userPrincipal;
        }
			  public string GetValue(int id)
				{
					return _appEntityAttributeValueRepository.GetValue(id);
				}	
			  public string GetDescription(int id)
				{
					return _appEntityAttributeValueRepository.GetDescription(id);
				}	
	
    }
}      
 