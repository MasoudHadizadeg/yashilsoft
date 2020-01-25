using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
    public class OrganizationService : GenericService<Organization, int>, IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IUnitOfWork unitOfWork, IOrganizationRepository organizationRepository,
            IUserPrincipal userPrincipal) : base(unitOfWork, organizationRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _organizationRepository = organizationRepository;
        }
    }
}