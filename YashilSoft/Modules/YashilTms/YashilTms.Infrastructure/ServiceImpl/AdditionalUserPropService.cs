	using System.Threading.Tasks;
    using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
	public class AdditionalUserPropService : GenericService<AdditionalUserProp,int>, IAdditionalUserPropService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IAdditionalUserPropRepository _additionalUserPropRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public AdditionalUserPropService (IUnitOfWork unitOfWork, IAdditionalUserPropRepository additionalUserPropRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, additionalUserPropRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_additionalUserPropRepository = additionalUserPropRepository;
			_userPrincipal = userPrincipal;
        }

        public AdditionalUserProp GetByUserId(int userId)
        {
            return _additionalUserPropRepository.GetByUserId(userId);
        }
    }
}      
 