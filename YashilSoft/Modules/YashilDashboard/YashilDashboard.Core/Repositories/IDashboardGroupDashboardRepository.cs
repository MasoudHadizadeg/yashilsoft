			
using System.Collections.Generic;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilDashboard.Core.Repositories
{
	public interface IDashboardGroupDashboardRepository : IGenericRepository<DashboardGroupDashboard>
    {
        Task AssignSelectedItemsToDashboardGroup(List<int> selectedDashboardStores, int dashboardGroupId, bool assign);
    }
}      
