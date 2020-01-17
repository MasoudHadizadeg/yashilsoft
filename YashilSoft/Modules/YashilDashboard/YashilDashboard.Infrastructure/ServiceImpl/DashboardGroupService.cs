using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
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
        private readonly ClaimsPrincipal _claimsPrincipal;
        public DashboardGroupService (IUnitOfWork unitOfWork, IDashboardGroupRepository dashboardGroupRepository, ClaimsPrincipal claimsPrincipal) : base(unitOfWork, dashboardGroupRepository)
        {
			_unitOfWork = unitOfWork;
			_dashboardGroupRepository = dashboardGroupRepository;
            _claimsPrincipal = claimsPrincipal;
        }

        public IQueryable<DashboardGroup> GetDashboardGroupList()
        {
            var currentUserId = Convert.ToInt32(this._claimsPrincipal.Identity.Name);
            return _dashboardGroupRepository.GetUserDashboardGroupList(currentUserId);
        }
    }
}      
 