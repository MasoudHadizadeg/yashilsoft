using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDashboard.Core.Repositories;
using YashilDashboard.Core.Services;

namespace YashilDashboard.Infrastructure.ServiceImpl
{
    public class RoleDashboardService : GenericService<RoleDashboard, int>, IRoleDashboardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleDashboardRepository _roleDashboardRepository;

        public RoleDashboardService(IUnitOfWork unitOfWork, IRoleDashboardRepository roleDashboardRepository,
            IUserPrincipal userPrincipal) : base(unitOfWork, roleDashboardRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _roleDashboardRepository = roleDashboardRepository;
        }
    }
}