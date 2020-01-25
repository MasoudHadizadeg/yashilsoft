using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
    public class RoleResourceActionService : GenericService<RoleResourceAction, int>, IRoleResourceActionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleResourceActionRepository _roleResourceActionRepository;

        public RoleResourceActionService(IUnitOfWork unitOfWork,
            IRoleResourceActionRepository roleResourceActionRepository, IUserPrincipal userPrincipal) : base(unitOfWork,
            roleResourceActionRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _roleResourceActionRepository = roleResourceActionRepository;
        }
    }
}