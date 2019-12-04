			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
	public class AppConfigRepository : GenericRepository<AppConfig,int>, IAppConfigRepository
    {
        private readonly YashilAppDbContext _context;
		public AppConfigRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
