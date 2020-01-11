using System.Security.Claims;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Yashil.Common.SharedKernel.Module;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;
using YashilUserManagement.Infrastructure.RepositoryImpl;
using YashilUserManagement.Infrastructure.ServiceImpl;
using Microsoft.Extensions.Configuration;
using Yashil.Common.Core.Interfaces;

namespace YashilUserManagement.Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void OnStartup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IYashilPasswordValidator<int>, PasswordValidator>();
            services.AddTransient<ClaimsPrincipal>(s => s.GetService<IHttpContextAccessor>().HttpContext.User);
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IAppActionRepository, AppActionRepository>();
            services.AddScoped<IAppActionService, AppActionService>();
            services.AddScoped<IResourceAppActionRepository, ResourceAppActionRepository>();
            services.AddScoped<IResourceAppActionService, ResourceAppActionService>();
            services.AddScoped<IRoleResourceActionRepository, RoleResourceActionRepository>();
            services.AddScoped<IRoleResourceActionService, RoleResourceActionService>();
            services.AddScoped<IAppConfigRepository, AppConfigRepository>();
            services.AddScoped<IAppConfigService, AppConfigService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IMenuRepository, MenuRepository>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IUserRoleService, UserRoleService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}