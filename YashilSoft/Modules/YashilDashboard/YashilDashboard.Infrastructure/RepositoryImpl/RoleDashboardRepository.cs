			
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data; 
using YashilDashboard.Core.Repositories;

namespace YashilDashboard.Infrastructure.RepositoryImpl
{
	public class RoleDashboardRepository : GenericRepository<RoleDashboard,int>, IRoleDashboardRepository
    {
        private readonly YashilAppDbContext _context;
		public RoleDashboardRepository (YashilAppDbContext context) : base(context)
            {
                _context = context;
            }
    }
}      
