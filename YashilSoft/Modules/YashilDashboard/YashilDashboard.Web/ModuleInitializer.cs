using System.Configuration;
using DevExpress.AspNetCore;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardCommon;
using DevExpress.DataAccess.ConnectionParameters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Yashil.Common.SharedKernel.Module;
using YashilDashboard.Core.Repositories;
using YashilDashboard.Core.Services;
using YashilDashboard.Infrastructure.RepositoryImpl;
using YashilDashboard.Infrastructure.ServiceImpl;
using Microsoft.Extensions.Configuration;
using YashilDashboard.Web.Classes;
using YashilBaseInfo.Core.Services;

namespace YashilDashboard.Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        private IServiceCollection _serviceCollection;
        public void OnStartup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            _serviceCollection = services;
            /*
             *     configurator.SetConnectionStringsProvider(
                        new DashboardConnectionStringsProvider(configuration, "DashboardConnectionStrings"));
             */
            DashboardExportSettings.CompatibilityMode = DashboardExportCompatibilityMode.Restricted;
            services.AddScoped<IDashboardConnectionStringRepository, DashboardConnectionStringRepository>();
            services.AddScoped<IDashboardConnectionStringService, DashboardConnectionStringService>();
            services.AddScoped<IUserDashboardRepository, UserDashboardRepository>();
            services.AddScoped<IUserDashboardService, UserDashboardService>();
            services.AddScoped<IRoleDashboardRepository, RoleDashboardRepository>();
            services.AddScoped<IRoleDashboardService, RoleDashboardService>();
            services.AddScoped<IDashboardGroupRepository, DashboardGroupRepository>();
            services.AddScoped<IDashboardGroupService, DashboardGroupService>();
            services.AddScoped<IDashboardStoreRepository, DashboardStoreRepository>();
            services.AddScoped<IDashboardStoreService, DashboardStoreService>();
            services.AddScoped<IDashboardGroupDashboardRepository, DashboardGroupDashboardRepository>();
            services.AddScoped<IDashboardGroupDashboardService, DashboardGroupDashboardService>();
            services.AddDevExpressControls()
                .AddControllersWithViews()
                .AddDefaultDashboardController((configurator, sProvider) =>
                {
                    configurator.ConfigureDataConnection += Configurator_ConfigureDataConnection;
                    // configurator.SetConnectionStringsProvider(new YashilDashboardConnectionStringsProvider(sProvider,configuration, "DashboardConnectionStrings"));
                    //configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(configuration, "DashboardConnectionStrings"));
                    configurator.SetDashboardStorage(new DataBaseEditableDashboardStorage(sProvider));

                });
        }
        private void Configurator_ConfigureDataConnection(object sender,
            DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
        {
            var dashboardService = _serviceCollection.BuildServiceProvider().CreateScope().ServiceProvider
                .GetRequiredService<IYashilConnectionStringService>();
            var conn = dashboardService.FindByName(e.ConnectionName);
            if (conn != null)
            {
                e.ConnectionParameters = new CustomStringConnectionParameters(conn.ConnectionString);
            }

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}