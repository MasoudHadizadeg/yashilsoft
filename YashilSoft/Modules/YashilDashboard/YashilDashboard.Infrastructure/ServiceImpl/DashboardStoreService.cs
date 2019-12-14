using System.Collections.Generic;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilDashboard.Core.Repositories;
using YashilDashboard.Core.Services;

namespace YashilDashboard.Infrastructure.ServiceImpl
{
    public class DashboardStoreService : GenericService<DashboardStore, int>, IDashboardStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDashboardStoreRepository _dashboardStoreRepository;

        public DashboardStoreService(IUnitOfWork unitOfWork, IDashboardStoreRepository dashboardStoreRepository) : base(
            unitOfWork, dashboardStoreRepository)
        {
            _unitOfWork = unitOfWork;
            _dashboardStoreRepository = dashboardStoreRepository;
        }

        public string GetDashboardDesigner(int dashboardId)
        {
            throw new System.NotImplementedException();
        }

        public string GetDashboardViewer(int dashboardId)
        {
            throw new System.NotImplementedException();
        }

        public async Task UpdateDashboardStoreWithConnectionStringAsync(DashboardStore entity,
            List<DashboardConnectionString> dashboardConnectionStrings,
            List<string> notModifiedProperties)
        {
            DeleteContentionStrings(entity.Id);
//            var report = AddConnectionStringToReport(entity.Id, reportConnectionStrings);
//            entity.ReportFile = report.SaveToByteArray();
            await UpdateAsync(entity, entity.Id, notModifiedProperties, true);
        }

        private void DeleteContentionStrings(in int entityId)
        {
            throw new System.NotImplementedException();
        }
    }
}