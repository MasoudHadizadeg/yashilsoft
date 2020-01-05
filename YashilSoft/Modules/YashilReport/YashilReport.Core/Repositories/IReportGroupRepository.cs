
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilReport.Core.Repositories
{
    public interface IReportGroupRepository : IGenericRepository<ReportGroup>
    {
        IQueryable<ReportGroup> GetByReportId(int id);
        IQueryable<ReportGroup> GetNotAssignedToReportId(int id);
    }
}      
