			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class RoleResourceActionRepository : GenericRepository<RoleResourceAction,int>, IRoleResourceActionRepository
    {
        private readonly YashilAppDbContext _context;
		public RoleResourceActionRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
