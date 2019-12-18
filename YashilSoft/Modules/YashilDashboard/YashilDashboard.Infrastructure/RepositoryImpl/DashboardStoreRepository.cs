
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilDashboard.Core.Repositories;

namespace YashilDashboard.Infrastructure.RepositoryImpl
{
    public class DashboardStoreRepository : GenericRepository<DashboardStore, int>, IDashboardStoreRepository
    {
        private readonly YashilAppDbContext _context;

        public DashboardStoreRepository(YashilAppDbContext context) : base(context)
        {
            _context = context;
        }

        public void DeleteContentionStrings(int dashboardId)
        {
            _context.DashboardConnectionString.RemoveRange(
                _context.DashboardConnectionString.Where(x => x.DashboardId == dashboardId));
        }
        public async Task<DashboardStore> GetForEditAsync(int dashboardId, bool readOnly = true)
        {
            return await _context.DashboardStore.Include(x => x.DashboardConnectionString).FirstOrDefaultAsync(x => x.Id == dashboardId);
        }
    }
}