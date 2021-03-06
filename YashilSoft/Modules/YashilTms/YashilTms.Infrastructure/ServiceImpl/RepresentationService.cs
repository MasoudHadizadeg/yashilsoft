using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
    public class RepresentationService : GenericService<Representation, int>, IRepresentationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepresentationRepository _representationRepository;
        private readonly IUserPrincipal _userPrincipal;

        public RepresentationService(IUnitOfWork unitOfWork, IRepresentationRepository representationRepository,
            IUserPrincipal userPrincipal)
            : base(unitOfWork, representationRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _representationRepository = representationRepository;
            _userPrincipal = userPrincipal;
        }

        public IQueryable<Representation> GetByEducationalCenterId(int educationalCenterId)
        {
            return _representationRepository.GetByEducationalCenterId(educationalCenterId);
        }
    }
}