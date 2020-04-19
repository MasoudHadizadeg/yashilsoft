using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Yashil.Common.SharedKernel.Module;
using YashilNews.Core.Repositories;
using YashilNews.Core.Services;
using YashilNews.Infrastructure.RepositoryImpl;
using YashilNews.Infrastructure.ServiceImpl;
using Microsoft.Extensions.Configuration;

namespace YashilNews.Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void OnStartup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMainNewsRepository, MainNewsRepository>();
            services.AddScoped<IMainNewsService, MainNewsService>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<INewsStoreRepository, NewsStoreRepository>();
            services.AddScoped<INewsStoreService, NewsStoreService>();
            services.AddScoped<INewsKeywordRepository, NewsKeywordRepository>();
            services.AddScoped<INewsKeywordService, NewsKeywordService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}