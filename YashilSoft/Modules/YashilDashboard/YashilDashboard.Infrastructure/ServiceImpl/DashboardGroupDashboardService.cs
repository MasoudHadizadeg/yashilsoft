			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDashboard.Core.Repositories;
using YashilDashboard.Core.Services;

namespace YashilDashboard.Infrastructure.ServiceImpl
{
	public class DashboardGroupDashboardService : GenericService<DashboardGroupDashboard,int>, IDashboardGroupDashboardService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IDashboardGroupDashboardRepository _dashboardGroupDashboardRepository;
       
		public DashboardGroupDashboardService (IUnitOfWork unitOfWork, IDashboardGroupDashboardRepository dashboardGroupDashboardRepository) : base(unitOfWork, dashboardGroupDashboardRepository)
        {
			_unitOfWork = unitOfWork;
			_dashboardGroupDashboardRepository = dashboardGroupDashboardRepository;
        }
    }
}      
 