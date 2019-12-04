			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilDashboard.Core.Repositories;

namespace YashilDashboard.Infrastructure.RepositoryImpl
{
	public class DashboardConnectionStringRepository : GenericRepository<DashboardConnectionString,int>, IDashboardConnectionStringRepository
    {
        private readonly YashilAppDbContext _context;
		public DashboardConnectionStringRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
