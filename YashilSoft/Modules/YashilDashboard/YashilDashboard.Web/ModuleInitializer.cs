using DevExpress.AspNetCore;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardCommon;
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
                    configurator.SetConnectionStringsProvider(
                        new DashboardConnectionStringsProvider(configuration, "DashboardConnectionStrings"));
                    configurator.SetDashboardStorage(new DataBaseEditableDashboardStorage(sProvider));
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}