using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilDashboard.Core.Repositories
{
    public interface IDashboardGroupRepository : IGenericRepository<DashboardGroup, int>
    {
        IQueryable<DashboardGroup> GetUserDashboardGroupList(int currentUserId);
        
    }
}