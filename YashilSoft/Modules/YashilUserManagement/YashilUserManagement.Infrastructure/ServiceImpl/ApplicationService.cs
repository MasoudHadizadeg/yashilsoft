using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
    public class ApplicationService : GenericService<Application, int>, IApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IUnitOfWork unitOfWork, IApplicationRepository applicationRepository,
            IUserPrincipal userPrincipal) : base(unitOfWork, applicationRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _applicationRepository = applicationRepository;
        }
    }
}