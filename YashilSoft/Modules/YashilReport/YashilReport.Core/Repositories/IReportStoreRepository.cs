using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Classes;
using Yashil.Core.Entities; 

namespace YashilReport.Core.Repositories
{
	public interface IReportStoreRepository : IGenericRepository<ReportStore>
    {
        void DeleteContentionStrings(int reportId);
        Task<ReportStore> GetForEditAsync(int reportId, bool readOnly = true);
        IQueryable<ReportStore> GetUserReportList(IUserPrincipal userPrincipal);
    }
}      
