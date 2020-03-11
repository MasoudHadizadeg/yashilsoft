using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilReport.Core.Repositories
{
	public interface IReportStoreRepository : IGenericRepository<ReportStore, int>
    {
        void DeleteContentionStrings(int reportId);
        Task<ReportStore> GetForEditAsync(int reportId, bool readOnly = true);
        IQueryable<ReportStore> GetUserReportList();
        IQueryable<ReportStore> GetReportStoresAssignedToGroupAsync(int groupId);
        IQueryable<ReportStore> GetReportStoresNotAssignedToGroupAsync( int groupId);
        IQueryable<ReportStore> GetReportStoresAssignedToRoleAsync(int id);
        IQueryable<ReportStore> GetReportStoresNotAssignedToRoleAsync(int id);
    }
}      
