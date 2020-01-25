using System.Linq;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using Yashil.Common.Core.Classes;
using YashilDashboard.Core.Repositories;

namespace YashilDashboard.Infrastructure.RepositoryImpl
{
    public class DashboardGroupRepository : GenericRepository<DashboardGroup, int>, IDashboardGroupRepository
    {
        private readonly YashilAppDbContext _context;

        public DashboardGroupRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
        {
            _context = context;
        }

        public IQueryable<DashboardGroup> GetUserDashboardGroupList(int currentUserId)
        {
            var userRoles = _context.UserRole.Where(x => x.UserId == currentUserId).Select(x => x.Role);
            var userDashboard = _context.DashboardStore.Where(x =>
                x.CreateBy == currentUserId || x.RoleDashboard.Any(c => userRoles.Contains(c.Role)) ||
                x.UserDashboard.Any(u => u.UserId == currentUserId)).Select(x => x.Id);
            return _context.DashboardGroup.Where(x =>
                x.DashboardGroupDashboard.Any(d => userDashboard.Contains(d.DashboardStoreId)));
        }
    }
}