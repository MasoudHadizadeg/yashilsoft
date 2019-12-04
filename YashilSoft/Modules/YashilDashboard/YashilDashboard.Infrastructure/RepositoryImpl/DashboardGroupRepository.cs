			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilDashboard.Core.Repositories;

namespace YashilDashboard.Infrastructure.RepositoryImpl
{
	public class DashboardGroupRepository : GenericRepository<DashboardGroup,int>, IDashboardGroupRepository
    {
        private readonly YashilAppDbContext _context;
		public DashboardGroupRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
