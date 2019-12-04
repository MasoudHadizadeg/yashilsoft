			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class UserRoleRepository : GenericRepository<UserRole,int>, IUserRoleRepository
    {
        private readonly YashilAppDbContext _context;
		public UserRoleRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
