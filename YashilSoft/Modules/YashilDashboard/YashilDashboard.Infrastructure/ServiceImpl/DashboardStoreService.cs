			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDashboard.Core.Repositories;
using YashilDashboard.Core.Services;

namespace YashilDashboard.Infrastructure.ServiceImpl
{
	public class DashboardStoreService : GenericService<DashboardStore,int>, IDashboardStoreService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IDashboardStoreRepository _dashboardStoreRepository;
       
		public DashboardStoreService (IUnitOfWork unitOfWork, IDashboardStoreRepository dashboardStoreRepository) : base(unitOfWork, dashboardStoreRepository)
        {
			_unitOfWork = unitOfWork;
			_dashboardStoreRepository = dashboardStoreRepository;
        }
    }
}      
 