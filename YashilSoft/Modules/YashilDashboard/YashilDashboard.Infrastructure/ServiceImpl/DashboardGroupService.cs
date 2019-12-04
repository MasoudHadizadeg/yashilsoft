			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDashboard.Core.Repositories;
using YashilDashboard.Core.Services;

namespace YashilDashboard.Infrastructure.ServiceImpl
{
	public class DashboardGroupService : GenericService<DashboardGroup,int>, IDashboardGroupService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IDashboardGroupRepository _dashboardGroupRepository;
       
		public DashboardGroupService (IUnitOfWork unitOfWork, IDashboardGroupRepository dashboardGroupRepository) : base(unitOfWork, dashboardGroupRepository)
        {
			_unitOfWork = unitOfWork;
			_dashboardGroupRepository = dashboardGroupRepository;
        }
    }
}      
 