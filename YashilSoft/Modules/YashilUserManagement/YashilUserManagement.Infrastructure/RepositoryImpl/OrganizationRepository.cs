			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class OrganizationRepository : GenericRepository<Organization,int>, IOrganizationRepository
    {
        private readonly YashilAppDbContext _context;
		public OrganizationRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
