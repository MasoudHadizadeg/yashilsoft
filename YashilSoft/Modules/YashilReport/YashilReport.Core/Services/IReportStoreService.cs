using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilReport.Core.Services
{
    public interface IReportStoreService : IGenericService<ReportStore>
    {
        string GetReportDesigner(int reportId);
        string GetReportViewer(int reportId);
        void DeleteContentionStrings(int reportId, bool save = false);
        Task<ReportStore> GetEntityForEdit(int reportId);
        Task UpdateReportStoreWithConnectionStringAsync(ReportStore entity, List<ReportConnectionString> reportConnectionStrings, List<string> notModifiedProperties);
        Result HandleReport(CommandJson command);
        IQueryable<ReportStore> GetReportList();
        IQueryable<ReportStore> GetReportStoresAssignedToGroupAsync(int id);
        IQueryable<ReportStore> GetReportStoresNotAssignedToGroupAsync(int id);
        Task<bool> AssignSelectedItemsToReportGroup(List<int> selectedReports, int groupId, bool assign);
        IQueryable<ReportStore> GetReportStoresAssignedToRoleAsync(int id);
        IQueryable<ReportStore> GetReportStoresNotAssignedToRoleAsync(int id);
        Task<bool> AssignSelectedReportSoresToRole(List<int> selectedReports, int groupId, bool assign);
    }
}