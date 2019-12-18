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

namespace YashilDashboard.Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void OnStartup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
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
                    configurator.SetConnectionStringsProvider(new YashilDashboardConnectionStringsProvider(configuration, "DashboardConnectionStrings"));
                    //configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(configuration, "DashboardConnectionStrings"));
                    configurator.SetDashboardStorage(new DataBaseEditableDashboardStorage(sProvider));

                });
        }
        private void Configurator_ConfigureDataConnection(object sender,
            DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
        {
            if (e.ConnectionName == "tbao")
            {
                
                //SQLiteConnectionParameters sqliteParams = new SQLiteConnectionParameters();
                //sqliteParams.FileName = "file:Data/nwind.db";
                //e.ConnectionParameters = sqliteParams;
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}