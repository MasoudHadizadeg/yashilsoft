			using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
	public class CommonBaseTypeService : GenericService<CommonBaseType,int>, ICommonBaseTypeService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly ICommonBaseTypeRepository _commonBaseTypeRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public CommonBaseTypeService (IUnitOfWork unitOfWork, ICommonBaseTypeRepository commonBaseTypeRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, commonBaseTypeRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_commonBaseTypeRepository = commonBaseTypeRepository;
			_userPrincipal = userPrincipal;
        }
    }
}      
 