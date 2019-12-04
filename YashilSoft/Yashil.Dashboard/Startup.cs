using System.IO;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Yashil.Core.Interfaces;
using Yashil.Core.Interfaces.Data;
using Yashil.Dashboard.Web.Classes.RequestFormatter;
using Yashil.Dashboard.Web.Data;
using Yashil.Dashboard.Web.Helpers;
using Yashil.SharedKernel.Helpers;

namespace Yashil.Dashboard.Web
{
    public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new DomainProfile()); });

      IMapper mapper = mappingConfig.CreateMapper();
      services.AddSingleton<IMapper>(mapper);
      services.AddAuthorization();
      services.AddCors();

      services.AddMvc(options =>
      {
        // options.Filters.Add(typeof(DynamicAuthorizationFilter));
        options.InputFormatters.Insert(0, new RawRequestBodyFormatter());
      }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
      // configure strongly typed settings objects
      var appSettingsSection = Configuration.GetSection("AppSettings");
      services.Configure<AppSettings>(appSettingsSection);

      // configure jwt authentication
      var appSettings = appSettingsSection.Get<AppSettings>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);
      CryptographyHelper.AesIv = appSettings.AESIv;
      CryptographyHelper.AesKey = appSettings.AESKey;

      services.AddAuthentication(x =>
        {
          x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
          x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
          x.RequireHttpsMetadata = false;
          x.SaveToken = true;
          x.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
          };
        });

      services.AddDbContext<YashilAppDbContext>(
        options => options.UseSqlServer(Configuration.GetConnectionString("TLSAppDB")));
      services.AddTransient<IUnitOfWork, UnitOfWork>();
      // Auto Mapper Configurations


      //services.AddMvc();
      // services.AddSpaStaticFiles(c => { c.RootPath = "ClientApp/dist"; });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
      ProjectConfiguration.FileRootPath = env.ContentRootPath;
//      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
//      loggerFactory.AddDebug();

      //  MapConfigurationFactory.Scan<Startup>();
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseHttpsRedirection();

      app.UseStaticFiles();
      //app.UseSpaStaticFiles();

      app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

      app.UseAuthentication();
      app.UseAuthorization();
      //      app.UseMvc(routes => { routes.MapRoute(name: "default", template: "{controller}/{action=index}/{id}"); });
      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller}/{action=Index}/{id?}");
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
