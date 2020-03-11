			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilDashboard.Core.Services
{
	public interface IDashboardGroupService : IGenericService<DashboardGroup, int>
    {
        IQueryable<DashboardGroup> GetDashboardGroupList();
    }
}      
 