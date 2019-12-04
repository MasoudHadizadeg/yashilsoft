			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilReport.Core.Repositories;
using YashilReport.Core.Services;

namespace YashilReport.Infrastructure.ServiceImpl
{
	public class ReportStoreService : GenericService<ReportStore,int>, IReportStoreService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IReportStoreRepository _reportStoreRepository;
       
		public ReportStoreService (IUnitOfWork unitOfWork, IReportStoreRepository reportStoreRepository) : base(unitOfWork, reportStoreRepository)
        {
			_unitOfWork = unitOfWork;
			_reportStoreRepository = reportStoreRepository;
        }
    }
}      
 