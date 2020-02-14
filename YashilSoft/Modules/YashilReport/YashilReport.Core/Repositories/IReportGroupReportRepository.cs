			
using System.Collections.Generic;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilReport.Core.Repositories
{
	public interface IReportGroupReportRepository : IGenericRepository<ReportGroupReport>
    {
        Task AssignSelectedItemsToReportGroup(List<int> selectedReports, int groupId, bool assign);
    }
}      
