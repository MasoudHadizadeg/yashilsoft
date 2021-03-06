using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilDashboard.Core.Repositories
{
	public interface IDashboardStoreRepository : IGenericRepository<DashboardStore, int>
    {
        void DeleteContentionStrings(int dashboardId);
        Task<DashboardStore> GetForEditAsync(int dashboardId, bool readOnly = false);
        IQueryable<DashboardStore> GetUserDashboardList();
        IQueryable<DashboardStore> GetDashboardStoresAssignedToGroupAsync(int groupId);
        IQueryable<DashboardStore> GetDashboardStoresNotAssignedToGroupAsync(int groupId);
    }
}      
