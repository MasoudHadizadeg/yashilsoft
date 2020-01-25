
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilReport.Core.Repositories
{
    public interface IReportGroupRepository : IGenericRepository<ReportGroup>
    {
        IQueryable<ReportGroup> GetByReportId(int id);
        IQueryable<ReportGroup> GetNotAssignedToReportId(int id);
        IQueryable<ReportGroup> GetUserReportGroupList(int currentUserId);
    }
}      
