			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilReport.Core.Repositories;
using YashilReport.Core.Services;

namespace YashilReport.Infrastructure.ServiceImpl
{
	public class ReportGroupReportService : GenericService<ReportGroupReport,int>, IReportGroupReportService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IReportGroupReportRepository _reportGroupReportRepository;
       
		public ReportGroupReportService (IUnitOfWork unitOfWork, IReportGroupReportRepository reportGroupReportRepository) : base(unitOfWork, reportGroupReportRepository)
        {
			_unitOfWork = unitOfWork;
			_reportGroupReportRepository = reportGroupReportRepository;
        }
    }
}      
 