using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Yashil.Common.SharedKernel.Module;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;
using Microsoft.Extensions.Configuration;
using Yashil.Core.ControllersExtenders;
using YashilTms.Infrastructure.RepositoryImpl;
using YashilTms.Infrastructure.ServiceImpl;
using YashilTms.Web.Areas.Tms.ControllersExtenders;

namespace YashilTms.Web
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void OnStartup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment)
        {
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAdditionalUserPropRepository, AdditionalUserPropRepository>();
            services.AddScoped<IAdditionalUserPropService, AdditionalUserPropService>();
            services.AddScoped<IUserControllerExtender, UserControllerExtender>();
            services.AddScoped<ICoursesPlanningStudentRepository, CoursesPlanningStudentRepository>();
            services.AddScoped<ICoursesPlanningStudentService, CoursesPlanningStudentService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICoursesPlanningRepository, CoursesPlanningRepository>();
            services.AddScoped<ICoursesPlanningService, CoursesPlanningService>();
            services.AddScoped<IRepresentationRepository, RepresentationRepository>();
            services.AddScoped<IRepresentationService, RepresentationService>();
            services.AddScoped<IRepresentationPersonRepository, RepresentationPersonRepository>();
            services.AddScoped<IRepresentationPersonService, RepresentationPersonService>();
            services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
            services.AddScoped<ICourseCategoryService, CourseCategoryService>();
            services.AddScoped<IEducationalCenterRepository, EducationalCenterRepository>();
            services.AddScoped<IEducationalCenterService, EducationalCenterService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}