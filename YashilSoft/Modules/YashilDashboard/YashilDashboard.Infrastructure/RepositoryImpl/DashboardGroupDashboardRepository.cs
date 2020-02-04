using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using Yashil.Common.Core.Classes;
using YashilDashboard.Core.Repositories;

namespace YashilDashboard.Infrastructure.RepositoryImpl
{
    public class DashboardGroupDashboardRepository : GenericRepository<DashboardGroupDashboard, int>,
        IDashboardGroupDashboardRepository
    {
        private readonly YashilAppDbContext _context;
        private readonly IUserPrincipal _userPrincipal;

        public DashboardGroupDashboardRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(
            context, userPrincipal)
        {
            _context = context;
            _userPrincipal = userPrincipal;
        }

        public async Task AssignSelectedItemsToDashboardGroup(List<int> selectedDashboardStores, int dashboardGroupId,
            bool assign)
        {
            List<DashboardGroupDashboard> dashboardGroupDashboards = new List<DashboardGroupDashboard>();
            foreach (var selectedDashboardStore in selectedDashboardStores)
            {
                var dashboardGroupDashboard = new DashboardGroupDashboard()
                {
                    CreateBy = _userPrincipal.Id,
                    CreationDate = DateTime.Now,
                    DashboardStoreId = selectedDashboardStore,
                    DashboardGroupId = dashboardGroupId
                };
                await AddAsync(dashboardGroupDashboard);
            }
        }
    }
}