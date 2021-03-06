using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
    public class RepresentationPersonService : GenericService<RepresentationPerson, int>, IRepresentationPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepresentationPersonRepository _representationPersonRepository;
        private readonly IUserPrincipal _userPrincipal;

        public RepresentationPersonService(IUnitOfWork unitOfWork,
            IRepresentationPersonRepository representationPersonRepository, IUserPrincipal userPrincipal)
            : base(unitOfWork, representationPersonRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _representationPersonRepository = representationPersonRepository;
            _userPrincipal = userPrincipal;
        }

        public IQueryable<RepresentationPerson> GetByRepresentationId(int representationId)
        {
            return _representationPersonRepository.GetByRepresentationId(representationId);
        }

        public IQueryable<RepresentationPerson> GetByCustomFilter(int? representationId, int? personId, int? postId)
        {
            return _representationPersonRepository.GetByCustomFilter(representationId, personId, postId);
        }

    }
}