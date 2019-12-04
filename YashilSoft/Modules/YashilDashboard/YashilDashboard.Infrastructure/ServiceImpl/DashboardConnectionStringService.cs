			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDashboard.Core.Repositories;
using YashilDashboard.Core.Services;

namespace YashilDashboard.Infrastructure.ServiceImpl
{
	public class DashboardConnectionStringService : GenericService<DashboardConnectionString,int>, IDashboardConnectionStringService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IDashboardConnectionStringRepository _dashboardConnectionStringRepository;
       
		public DashboardConnectionStringService (IUnitOfWork unitOfWork, IDashboardConnectionStringRepository dashboardConnectionStringRepository) : base(unitOfWork, dashboardConnectionStringRepository)
        {
			_unitOfWork = unitOfWork;
			_dashboardConnectionStringRepository = dashboardConnectionStringRepository;
        }
    }
}      
 