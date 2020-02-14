
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Yashil.Common.SharedKernel.Module;
using YashilDms.Core.Repositories;
using YashilDms.Core.Services;
using YashilDms.Infrastructure.RepositoryImpl;
using YashilDms.Infrastructure.ServiceImpl;
using Microsoft.Extensions.Configuration;

namespace YashilDms.Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void OnStartup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {

        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
	                         services.AddScoped<IDocFormatRepository, DocFormatRepository>();
                 services.AddScoped<IDocFormatService, DocFormatService>();
                              services.AddScoped<IDocumentCategoryRepository, DocumentCategoryRepository>();
                 services.AddScoped<IDocumentCategoryService, DocumentCategoryService>();
                              services.AddScoped<IAppDocumentRepository, AppDocumentRepository>();
                 services.AddScoped<IAppDocumentService, AppDocumentService>();
                              services.AddScoped<IDocTypeRepository, DocTypeRepository>();
                 services.AddScoped<IDocTypeService, DocTypeService>();
                     
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}