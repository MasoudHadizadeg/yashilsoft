	using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
	public class AppEntityAttributeService : GenericService<AppEntityAttribute,int>, IAppEntityAttributeService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IAppEntityAttributeRepository _appEntityAttributeRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public AppEntityAttributeService (IUnitOfWork unitOfWork, IAppEntityAttributeRepository appEntityAttributeRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, appEntityAttributeRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_appEntityAttributeRepository = appEntityAttributeRepository;
			_userPrincipal = userPrincipal;
        }
			  public string GetAllowedValues(int id)
				{
					return _appEntityAttributeRepository.GetAllowedValues(id);
				}	
			  public string GetDescription(int id)
				{
					return _appEntityAttributeRepository.GetDescription(id);
				}	
	
    }
}      
 