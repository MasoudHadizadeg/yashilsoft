			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilReport.Core.Repositories;
using YashilReport.Core.Services;

namespace YashilReport.Infrastructure.ServiceImpl
{
	public class ReportConnectionStringService : GenericService<ReportConnectionString,int>, IReportConnectionStringService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IReportConnectionStringRepository _reportConnectionStringRepository;
       
		public ReportConnectionStringService (IUnitOfWork unitOfWork, IReportConnectionStringRepository reportConnectionStringRepository) : base(unitOfWork, reportConnectionStringRepository)
        {
			_unitOfWork = unitOfWork;
			_reportConnectionStringRepository = reportConnectionStringRepository;
        }
    }
}      
 