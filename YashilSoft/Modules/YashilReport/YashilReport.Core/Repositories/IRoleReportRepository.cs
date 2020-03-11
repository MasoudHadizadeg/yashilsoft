			
using System.Collections.Generic;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilReport.Core.Repositories
{
	public interface IRoleReportRepository : IGenericRepository<RoleReport, int>
    {
        Task AssignSelectedReportSoresToRole(List<int> selectedReports, int groupId, bool assign);
    }
}      
