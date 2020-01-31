using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DevExpress.DashboardCommon;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Common.SharedKernel.Helpers;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using YashilDashboard.Core.Repositories;
using YashilDashboard.Core.Services;

namespace YashilDashboard.Infrastructure.ServiceImpl
{
    public class DashboardStoreService : GenericService<DashboardStore, int>, IDashboardStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDashboardStoreRepository _dashboardStoreRepository;
        private readonly IYashilConnectionStringService _connectionStringService;
        private readonly IDashboardConnectionStringService _dashboardConnectionStringService;
        private readonly ClaimsPrincipal _claimsPrincipal;

        public DashboardStoreService(IUnitOfWork unitOfWork, IDashboardStoreRepository dashboardStoreRepository,
            IYashilConnectionStringService connectionStringService,
            IDashboardConnectionStringService dashboardConnectionStringService, ClaimsPrincipal claimsPrincipal,
            IUserPrincipal userPrincipal) : base(unitOfWork, dashboardStoreRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _dashboardStoreRepository = dashboardStoreRepository;
            _connectionStringService = connectionStringService;
            _dashboardConnectionStringService = dashboardConnectionStringService;
            _claimsPrincipal = claimsPrincipal;
        }

        public string GetDashboardDesigner(int dashboardId)
        {
            throw new System.NotImplementedException();
        }

        public string GetDashboardViewer(int dashboardId)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateDashboardStoreWithConnectionStringAsync(DashboardStore entity, List<DashboardConnectionString> dashboardConnectionStrings)
        {
            DeleteContentionStrings(entity.Id);
            var dashboard = AddConnectionStringToDashboard(entity.Id, dashboardConnectionStrings);
            entity.DashboardFile = XDocumentHelper.GetBytes(dashboard.SaveToXDocument());
            // entity.DashboardFile= dashboard
            await UpdateAsync(entity, entity.Id, true);
        }

        public async Task<DashboardStore> GetEntityForEdit(int dashboardId)
        {
            return await _dashboardStoreRepository.GetForEditAsync(dashboardId);
        }

        public IQueryable<DashboardStore> GetDashboardList()
        {
            var currentUserId = Convert.ToInt32(this._claimsPrincipal.Identity.Name);
            return _dashboardStoreRepository.GetUserDashboardList();
        }

        private Dashboard AddConnectionStringToDashboard(int dashboardId,
            List<DashboardConnectionString> dashboardConnectionStrings)
        {
            var dashboardStore = Get(dashboardId);
            var dashboard = new Dashboard();
            var stream = new MemoryStream(dashboardStore.DashboardFile);
            dashboard.LoadFromXml(stream);

            var connectionStrings =
                _connectionStringService.FindByIds(dashboardConnectionStrings.Select(x => x.ConnectionStringId));

            dashboard.DataSources.Clear();


            foreach (var connectionString in dashboardConnectionStrings)
            {
                _dashboardConnectionStringService.Add(connectionString);
            }

            foreach (var connection in connectionStrings)
            {
                AddDatabaseToDashboard(dashboard, connection);
            }

            return dashboard;
        }

        private void DeleteContentionStrings(int dashboardId)
        {
            _dashboardStoreRepository.DeleteContentionStrings(dashboardId);
        }

        public override async Task<DashboardStore> AddAsync(DashboardStore dashboardStore, bool saveAfterAdd = false)
        {
            var dashboard = new Dashboard();
            var connectionStrings =
                _connectionStringService.FindByIds(
                    dashboardStore.DashboardConnectionString.Select(x => x.ConnectionStringId));
            foreach (var connection in connectionStrings)
            {
                AddDatabaseToDashboard(dashboard, connection);
            }

            dashboardStore.DashboardFile = XDocumentHelper.GetBytes(dashboard.SaveToXDocument());
            return await base.AddAsync(dashboardStore, saveAfterAdd);
        }

        private void AddDatabaseToDashboard(Dashboard dashboard, YashilConnectionString connection)
        {
            if (connection.DataProvider.Title == "MS SQL")
            {
                DashboardSqlDataSource dashboardSqlDataSource =
                    new DashboardSqlDataSource(connection.Title, connection.Title);
                dashboard.DataSources.Add(dashboardSqlDataSource);
            }
        }
    }
}