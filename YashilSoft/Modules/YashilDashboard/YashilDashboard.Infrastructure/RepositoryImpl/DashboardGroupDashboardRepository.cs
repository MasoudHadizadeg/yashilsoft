			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilDashboard.Core.Repositories;

namespace YashilDashboard.Infrastructure.RepositoryImpl
{
	public class DashboardGroupDashboardRepository : GenericRepository<DashboardGroupDashboard,int>, IDashboardGroupDashboardRepository
    {
        private readonly YashilAppDbContext _context;
		public DashboardGroupDashboardRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
