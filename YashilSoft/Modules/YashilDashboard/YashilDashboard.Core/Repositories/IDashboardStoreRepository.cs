using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilDashboard.Core.Repositories
{
	public interface IDashboardStoreRepository : IGenericRepository<DashboardStore>
    {
        void DeleteContentionStrings(int dashboardId);
        Task<DashboardStore> GetForEditAsync(int dashboardId, bool readOnly = false);
    }
}      
