
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Yashil.Common.SharedKernel.Module;
using YashilBaseInfo.Core.Repositories;
using YashilBaseInfo.Core.Services;
using YashilBaseInfo.Infrastructure.RepositoryImpl;
using YashilBaseInfo.Infrastructure.ServiceImpl;
using Microsoft.Extensions.Configuration;

namespace YashilBaseInfo.Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void OnStartup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {

        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
	                         services.AddScoped<IYashilDataProviderRepository, YashilDataProviderRepository>();
                 services.AddScoped<IYashilDataProviderService, YashilDataProviderService>();
                              services.AddScoped<IYashilConnectionStringRepository, YashilConnectionStringRepository>();
                 services.AddScoped<IYashilConnectionStringService, YashilConnectionStringService>();
                              services.AddScoped<IAccessLevelRepository, AccessLevelRepository>();
                 services.AddScoped<IAccessLevelService, AccessLevelService>();
                     
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}