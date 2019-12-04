			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
	public class RoleService : GenericService<Role,int>, IRoleService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleRepository _roleRepository;
       
		public RoleService (IUnitOfWork unitOfWork, IRoleRepository roleRepository) : base(unitOfWork, roleRepository)
        {
			_unitOfWork = unitOfWork;
			_roleRepository = roleRepository;
        }
    }
}      
 