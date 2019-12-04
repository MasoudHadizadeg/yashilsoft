			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;

namespace YashilBaseInfo.Infrastructure.ServiceImpl
{
	public class AccessLevelService : GenericService<AccessLevel,int>, IAccessLevelService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IAccessLevelRepository _accessLevelRepository;
       
		public AccessLevelService (IUnitOfWork unitOfWork, IAccessLevelRepository accessLevelRepository) : base(unitOfWork, accessLevelRepository)
        {
			_unitOfWork = unitOfWork;
			_accessLevelRepository = accessLevelRepository;
        }
    }
}      
 