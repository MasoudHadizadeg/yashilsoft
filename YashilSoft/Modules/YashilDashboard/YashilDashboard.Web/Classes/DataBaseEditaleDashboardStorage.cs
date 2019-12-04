using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DevExpress.DashboardWeb;
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
            IDashboardStoreService dashboardService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IDashboardStoreService>();
            var dashboardStore = new DashboardStore
            {
                AccessLevelId = 1,
                CreateBy = 7,
                CreationDate = DateTime.Now,
                DashboardFile = XDocumentHelper.GetDashboardFile(document),
                Title = dashboardName
            };
            dashboardService.AddAsync(dashboardStore,true);

            return dashboardStore.Id.ToString();
        }


        XDocument IDashboardStorage.LoadDashboard(string dashboardId)
        {
            //IDashboardStoreService dashboardService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IDashboardStoreService>();
            //var dashboardStore = dashboardService.GetAsync(Int32.Parse(dashboardId), true);
            //var stream = new MemoryStream(dashboardStore.DashboardFile);

            //return XDocument.Load(stream);
            return null;
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
            //IDashboardStoreService dashboardService = _serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IDashboardStoreService>();
            //dashboardService.UpdateDashboardFile(Int32.Parse(dashboardId), document);
            //dashboardService.SaveChange();
            
        }
    }
}
