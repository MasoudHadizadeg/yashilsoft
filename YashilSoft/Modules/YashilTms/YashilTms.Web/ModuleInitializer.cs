using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Yashil.Common.SharedKernel.Module;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;
using YashilTms.Infrastructure.RepositoryImpl;
using YashilTms.Infrastructure.ServiceImpl;
using Microsoft.Extensions.Configuration;
using Yashil.Core.ControllersExtenders;
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
            services.AddScoped<IUserControllerExtender, UserControllerExtender>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IRepresentationRepository, RepresentationRepository>();
            services.AddScoped<IRepresentationService, RepresentationService>();
            services.AddScoped<IRepresentationPersonRepository, RepresentationPersonRepository>();
            services.AddScoped<IRepresentationPersonService, RepresentationPersonService>();
            services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
            services.AddScoped<ICourseCategoryService, CourseCategoryService>();
            services.AddScoped<IEducationalCenterRepository, EducationalCenterRepository>();
            services.AddScoped<IEducationalCenterService, EducationalCenterService>();
            services.AddScoped<IAdditionalUserPropRepository, AdditionalUserPropRepository>();
            services.AddScoped<IAdditionalUserPropService, AdditionalUserPropService>();
            services.AddScoped<IMainCourseCategoryRepository, MainCourseCategoryRepository>();
            services.AddScoped<IMainCourseCategoryService, MainCourseCategoryService>();
            services.AddScoped<IEducationalCenterMainCourseCategoryRepository, EducationalCenterMainCourseCategoryRepository>();
            services.AddScoped<IEducationalCenterMainCourseCategoryService, EducationalCenterMainCourseCategoryService>();
            services.AddScoped<ICoursePlanningStudentRepository, CoursePlanningStudentRepository>();
            services.AddScoped<ICoursePlanningStudentService, CoursePlanningStudentService>();
            services.AddScoped<ICoursePlanningRepository, CoursePlanningRepository>();
            services.AddScoped<ICoursePlanningService, CoursePlanningService>();
            services.AddScoped<IRepresentationTeacherRepository, RepresentationTeacherRepository>();
            services.AddScoped<IRepresentationTeacherService, RepresentationTeacherService>();
            services.AddScoped<IRepresentationCourseCategoryRepository, RepresentationCourseCategoryRepository>();
            services.AddScoped<IRepresentationCourseCategoryService, RepresentationCourseCategoryService>();
            services.AddScoped<IRepresentationEstablishedLicenseTypeRepository, RepresentationEstablishedLicenseTypeRepository>();
            services.AddScoped<IRepresentationEstablishedLicenseTypeService, RepresentationEstablishedLicenseTypeService>();
            services.AddScoped<IPersonBankAccountRepository, PersonBankAccountRepository>();
            services.AddScoped<IPersonBankAccountService, PersonBankAccountService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }
}