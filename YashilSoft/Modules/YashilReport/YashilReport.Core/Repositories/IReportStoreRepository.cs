			
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilReport.Core.Repositories
{
	public interface IReportStoreRepository : IGenericRepository<ReportStore>
    {
        void DeleteContentionString(int reportId);
        Task<ReportStore> GetForEditAsync(int reportId, bool readOnly = true);
    }
}      
