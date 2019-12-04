			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class RoleRepository : GenericRepository<Role,int>, IRoleRepository
    {
        private readonly YashilAppDbContext _context;
		public RoleRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
