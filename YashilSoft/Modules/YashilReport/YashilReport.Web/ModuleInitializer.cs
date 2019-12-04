
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Yashil.Common.SharedKernel.Module;
using YashilReport.Core.Repositories;
using YashilReport.Core.Services;
using YashilReport.Infrastructure.RepositoryImpl;
using YashilReport.Infrastructure.ServiceImpl;
using Microsoft.Extensions.Configuration;

namespace YashilReport.Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void OnStartup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {

        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
	                         services.AddScoped<IReportConnectionStringRepository, ReportConnectionStringRepository>();
                 services.AddScoped<IReportConnectionStringService, ReportConnectionStringService>();
                              services.AddScoped<IRoleReportRepository, RoleReportRepository>();
                 services.AddScoped<IRoleReportService, RoleReportService>();
                              services.AddScoped<IReportStoreRepository, ReportStoreRepository>();
                 services.AddScoped<IReportStoreService, ReportStoreService>();
                              services.AddScoped<IReportGroupRepository, ReportGroupRepository>();
                 services.AddScoped<IReportGroupService, ReportGroupService>();
                              services.AddScoped<IUserReportRepository, UserReportRepository>();
                 services.AddScoped<IUserReportService, UserReportService>();
                              services.AddScoped<IReportGroupReportRepository, ReportGroupReportRepository>();
                 services.AddScoped<IReportGroupReportService, ReportGroupReportService>();
                     
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}