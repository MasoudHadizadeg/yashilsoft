			
using System.Collections.Generic;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilDashboard.Core.Services
{
	public interface IDashboardStoreService : IGenericService<DashboardStore>
    {
        string GetDashboardDesigner(int dashboardId);
        string GetDashboardViewer( int dashboardId);
        Task UpdateDashboardStoreWithConnectionStringAsync(DashboardStore entity, List<DashboardConnectionString> dashboardConnectionStrings, List<string> getModifiedProperties);
        /// <summary>
        /// Get Dashboard Including ConnectionString
        /// </summary>
        /// <param name="dashboardId"></param>
        /// <returns></returns>
        Task<DashboardStore> GetEntityForEdit(int dashboardId);
    }
}      
 