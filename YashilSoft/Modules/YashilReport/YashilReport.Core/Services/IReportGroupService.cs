
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilReport.Core.Services
{
    public interface IReportGroupService : IGenericService<ReportGroup>
    {
        IQueryable<ReportGroup> GetByReportId(int id);
        IQueryable<ReportGroup> GetNotAssignedToReportId(int id);
        IQueryable<ReportGroup> GetReportGroupList();
    }
}      
 