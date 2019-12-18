using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Yashil.Common.SharedKernel.Module
{
    public interface IModuleInitializer
    {

        void OnStartup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment);
        void ConfigureServices(IServiceCollection serviceCollection, IConfiguration configuration);

        void Configure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
