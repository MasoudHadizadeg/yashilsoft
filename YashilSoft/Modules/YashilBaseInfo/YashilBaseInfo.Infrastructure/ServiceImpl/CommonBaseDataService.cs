	using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
	public class CommonBaseDataService : GenericService<CommonBaseData,int>, ICommonBaseDataService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonBaseDataRepository _commonBaseDataRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public CommonBaseDataService (IUnitOfWork unitOfWork, ICommonBaseDataRepository commonBaseDataRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, commonBaseDataRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_commonBaseDataRepository = commonBaseDataRepository;
			_userPrincipal = userPrincipal;
        }
			  public string GetExtendedProps(int id)
				{
					return _commonBaseDataRepository.GetExtendedProps(id);
				}	
			  public string GetDescription(int id)
				{
					return _commonBaseDataRepository.GetDescription(id);
				}	
	
    }
}      
 