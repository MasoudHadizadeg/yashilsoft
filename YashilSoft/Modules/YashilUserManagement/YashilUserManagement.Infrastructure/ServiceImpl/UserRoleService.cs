			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
	public class UserRoleService : GenericService<UserRole,int>, IUserRoleService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRoleRepository _userRoleRepository;
       
		public UserRoleService (IUnitOfWork unitOfWork, IUserRoleRepository userRoleRepository) : base(unitOfWork, userRoleRepository)
        {
			_unitOfWork = unitOfWork;
			_userRoleRepository = userRoleRepository;
        }
    }
}      
 