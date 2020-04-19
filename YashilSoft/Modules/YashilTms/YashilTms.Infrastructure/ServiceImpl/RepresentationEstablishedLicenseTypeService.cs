	using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
	public class RepresentationEstablishedLicenseTypeService : GenericService<RepresentationEstablishedLicenseType,int>, IRepresentationEstablishedLicenseTypeService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IRepresentationEstablishedLicenseTypeRepository _representationEstablishedLicenseTypeRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public RepresentationEstablishedLicenseTypeService (IUnitOfWork unitOfWork, IRepresentationEstablishedLicenseTypeRepository representationEstablishedLicenseTypeRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, representationEstablishedLicenseTypeRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_representationEstablishedLicenseTypeRepository = representationEstablishedLicenseTypeRepository;
			_userPrincipal = userPrincipal;
        }
                 
        public IQueryable<RepresentationEstablishedLicenseType> GetByCustomFilter( int? representationId, int? establishedLicenseType)
        {
            return _representationEstablishedLicenseTypeRepository.GetByCustomFilter(representationId,establishedLicenseType);
        }
           

    }
}      
 