			
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDashboard.Core.Repositories;
using YashilDashboard.Core.Services;

namespace YashilDashboard.Infrastructure.ServiceImpl
{
	public class UserDashboardService : GenericService<UserDashboard,int>, IUserDashboardService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IUserDashboardRepository _userDashboardRepository;
       
		public UserDashboardService (IUnitOfWork unitOfWork, IUserDashboardRepository userDashboardRepository) : base(unitOfWork, userDashboardRepository)
        {
			_unitOfWork = unitOfWork;
			_userDashboardRepository = userDashboardRepository;
        }
    }
}      
 