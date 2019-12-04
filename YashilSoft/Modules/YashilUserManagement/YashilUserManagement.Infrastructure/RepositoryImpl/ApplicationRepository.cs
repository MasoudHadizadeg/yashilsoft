			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class ApplicationRepository : GenericRepository<Application,int>, IApplicationRepository
    {
        private readonly YashilAppDbContext _context;
		public ApplicationRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
