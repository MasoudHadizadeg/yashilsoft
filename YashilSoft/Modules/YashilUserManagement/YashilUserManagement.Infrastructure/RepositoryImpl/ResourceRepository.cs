			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class ResourceRepository : GenericRepository<Resource,int>, IResourceRepository
    {
        private readonly YashilAppDbContext _context;
		public ResourceRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
