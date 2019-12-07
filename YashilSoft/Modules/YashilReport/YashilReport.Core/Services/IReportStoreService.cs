			
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilReport.Core.Services
{
	public interface IReportStoreService : IGenericService<ReportStore>
    {
        Task<bool> SaveReportDesign(int dataReportId, string dataReportFile);
        string GetReportDesigner(int  reportId);
    }
}      
 