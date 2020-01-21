using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using DevExpress.AspNetCore;
using DevExpress.DashboardAspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Common.SharedKernel;
using Yashil.Common.SharedKernel.Module;
using Yashil.Common.SharedKernel.Web;
using Yashil.Infrastructure.Data;
using Yashil.Runtime.RequestFormatter;
using Yashil.WebHost.Extensions;


namespace Yashil.WebHost
{
    public class Startup
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            foreach (var module in GlobalConfiguration.Modules)
            {
                var moduleInitializerType = module.Assembly.GetTypes()
                    .FirstOrDefault(t => typeof(IModuleInitializer).IsAssignableFrom(t));
                if (moduleInitializerType != null && moduleInitializerType != typeof(IModuleInitializer))
                {
                    var moduleInitializer = (IModuleInitializer) Activator.CreateInstance(moduleInitializerType);
                    moduleInitializer.OnStartup(configuration, hostingEnvironment);
                }
            }

            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(hostingEnvironment.ContentRootPath)
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.WithHeaders("Content-Type");
                });
            });
            services.AddControllersWithViews(x => x.InputFormatters.Insert(0, new RawRequestBodyFormatter()));
            // In production, the Angular files will be served from this directory
            // services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });

            GlobalConfiguration.WebRootPath = _hostingEnvironment.WebRootPath;
            GlobalConfiguration.ContentRootPath = _hostingEnvironment.ContentRootPath;
            services.AddRazorPages();
            services.AddModules(_hostingEnvironment.ContentRootPath);
            // services.AddCustomizedMvc(GlobalConfiguration.Modules); TODO:FIX THIS REMOVE COMMENT
            services.Configure<RazorViewEngineOptions>(
                options => { options.ViewLocationExpanders.Add(new ThemeableViewLocationExpander()); });
            services.AddDbContext<YashilAppDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("YashilAppDB")));
            services.AddScoped<IUnitOfWork, UnitOfWork<YashilAppDbContext>>();

            // var config = new MapperConfiguration();
            List<IOrderedMapperProfile> orderedMapperProfiles = new List<IOrderedMapperProfile>();
            foreach (var module in GlobalConfiguration.Modules)
            {
                var moduleInitializerType = module.Assembly.GetTypes()
                    .FirstOrDefault(t => typeof(IModuleInitializer).IsAssignableFrom(t));
                if (moduleInitializerType != null && moduleInitializerType != typeof(IModuleInitializer))
                {
                    var moduleInitializer = (IModuleInitializer) Activator.CreateInstance(moduleInitializerType);
                    services.AddSingleton(typeof(IModuleInitializer), moduleInitializer);
                    moduleInitializer.ConfigureServices(services, _configuration);
                }

                var orderedMapperProfile = module.Assembly.GetTypes()
                    .FirstOrDefault(t => typeof(IOrderedMapperProfile).IsAssignableFrom(t));
                if (orderedMapperProfile != null)
                {
                    orderedMapperProfiles.Add((IOrderedMapperProfile) Activator.CreateInstance(orderedMapperProfile));
                }
            }

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                foreach (var instance in orderedMapperProfiles)
                {
                    cfg.AddProfile(instance.GetType());
                }
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton<IMapper>(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseRouting();
            app.UseDevExpressControls();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                EndpointRouteBuilderExtension.MapDashboardRoute(endpoints, "api/dashboard");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 404
                    && !Path.HasExtension(context.Request.Path.Value))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";
                //spa.Options.DefaultPage = "";
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}