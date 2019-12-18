using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.Sql;
using Microsoft.Extensions.DependencyInjection;
using Yashil.Common.SharedKernel.Helpers;
using Yashil.Core.Entities;
using YashilDashboard.Core.Services;
using YashilDashboard.Web.Areas.Dash.ViewModels;

namespace YashilDashboard.Web.Classes
{
    public class DataBaseEditableDashboardStorage : IEditableDashboardStorage
    {
        // private readonly IDashboardStoreService _dashboardService;
        private readonly IServiceProvider _serviceProvider;

        public DataBaseEditableDashboardStorage(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        string IEditableDashboardStorage.AddDashboard(XDocument document, string dashboardName)
        {
//            Dashboard dashboard=new Dashboard();
//            var sqlDataConnection = new SqlDataConnection {Name = "conn1"};
//            dashboard.DataConnections.Add(sqlDataConnection);
            var dashboardService = _serviceProvider.CreateScope().ServiceProvider
                .GetRequiredService<IDashboardStoreService>();
            var dashboardStore = new DashboardStore
            {
                AccessLevelId = 1,
                CreateBy = 7,
                CreationDate = DateTime.Now,
                DashboardFile = XDocumentHelper.GetBytes(document),
                Title = dashboardName
            };
            dashboardService.AddAsync(dashboardStore, true);

            return dashboardStore.Id.ToString();
        }


        XDocument IDashboardStorage.LoadDashboard(string dashboardId)
        {
            var dashboardService = _serviceProvider.CreateScope().ServiceProvider
                .GetRequiredService<IDashboardStoreService>();
            var dashboardStore = dashboardService.Get(Int32.Parse(dashboardId), true);

            if (dashboardStore?.DashboardFile != null)
            {
                var stream = new MemoryStream(dashboardStore.DashboardFile);
                return XDocument.Load(stream);
            }

            return new XDocument();
        }

        IEnumerable<DashboardInfo> IDashboardStorage.GetAvailableDashboardsInfo()
        {
            //IDashboardStoreService dashboardService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IDashboardStoreService>();
            //var dashboardStores = dashboardService.GetAll(true)
            //    .Select(x => new DashboardInfo { ID = x.Id.ToString(), Name = x.Title }).ToList();
            //return dashboardStores;
            return null;
        }

        void IDashboardStorage.SaveDashboard(string dashboardId, XDocument document)
        {
            var stream = new MemoryStream();
            document.Save(stream);
            stream.Position = 0;
            var dashboardService = _serviceProvider.CreateScope().ServiceProvider
                .GetRequiredService<IDashboardStoreService>();
            var dashboardStore = new DashboardStore
            {
                Id = Convert.ToInt32(dashboardId), DashboardFile = stream.ToArray(), ModificationDate = DateTime.Now
            };

            dashboardService.Update(dashboardStore, dashboardStore.Id, new List<string> {"DashboardFile"}, true);
        }

         
    }
}