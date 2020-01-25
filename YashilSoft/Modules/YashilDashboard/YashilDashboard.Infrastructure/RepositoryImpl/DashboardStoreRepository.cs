using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using Yashil.Common.Core.Classes;
using YashilDashboard.Core.Repositories;

namespace YashilDashboard.Infrastructure.RepositoryImpl
{
    public class DashboardStoreRepository : GenericRepository<DashboardStore, int>, IDashboardStoreRepository
    {
        private readonly YashilAppDbContext _context;

        private readonly IUserPrincipal _userPrincipal;

        public DashboardStoreRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context,
            userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public void DeleteContentionStrings(int dashboardId)
        {
            _context.DashboardConnectionString.RemoveRange(
                _context.DashboardConnectionString.Where(x => x.DashboardId == dashboardId));
        }

        public async Task<DashboardStore> GetForEditAsync(int dashboardId, bool readOnly = true)
        {
            return await _context.DashboardStore.Include(x => x.DashboardConnectionString)
                .Where(CheckDashboardAccess(dashboardId)).FirstOrDefaultAsync();
        }

        private Expression<Func<DashboardStore, bool>> CheckDashboardAccess(int? dashboardId = null)
        {
            var userRoles = _context.UserRole.Where(x => x.UserId == _userPrincipal.Id).Select(x => x.Role);
            return x =>
                x.CreateBy == _userPrincipal.Id || x.RoleDashboard.Any(c => userRoles.Contains(c.Role)) ||
                x.UserDashboard.Any(u => u.UserId == _userPrincipal.Id);
        }

        public IQueryable<DashboardStore> GetUserDashboardList()
        {
            return _context.DashboardStore.Where(CheckDashboardAccess());
        }
    }
}