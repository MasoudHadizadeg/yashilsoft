using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;
using AutoMapper;
using Yashil.Core.Entities;
using YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms
{
    public class YashilTmsProfile : Profile, IOrderedMapperProfile
    {
        public int Order => 1;

        public YashilTmsProfile()
        {
            CreateMap<CoursePlanningStudent, CoursePlanningStudentEditModel>();

            CreateMap<CoursePlanningStudent, CoursePlanningStudentListViewModel>()
                .ForMember(x => x.CoursePlanningTitle,
                    b => b.MapFrom(c => c.CoursePlanning.Course.Title))
                .ForMember(x => x.PersonTitle,
                    b => b.MapFrom(c => c.Person.Name))
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));
            CreateMap<CoursePlanningStudentEditModel, CoursePlanningStudent>();

            CreateMap<CoursePlanningStudent, CoursePlanningStudentSimpleViewModel>();


            CreateMap<Course, CourseEditModel>();

            CreateMap<Course, CourseListViewModel>()
                .ForMember(x => x.CourseCategoryTitle,
                    b => b.MapFrom(c => c.CourseCategory.Title))
                .ForMember(x => x.EducationalCenterTitle,
                    b => b.MapFrom(c => c.EducationalCenter.Title))
                .ForMember(x => x.SkillTypeTitle, b => b.MapFrom(c => c.SkillTypeNavigation.Title))
                .ForMember(x => x.CertificateTypeTitle, b => b.MapFrom(c => c.CertificateTypeNavigation.Title))
                .ForMember(x => x.EvaluationMethodTitle, b => b.MapFrom(c => c.EvaluationMethodNavigation.Title))
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title))
                ;
            CreateMap<CourseEditModel, Course>();

            CreateMap<Course, CourseSimpleViewModel>();


            CreateMap<CoursePlanning, CoursePlanningEditModel>().ForMember(x => x.CourseCategoryId,
                    x => x.MapFrom(b => b.Course.CourseCategoryId))
                .ForMember(x => x.CourseTitle,
                    x => x.MapFrom(b => b.Course.Title));


            CreateMap<CoursePlanning, CoursePlanningListViewModel>()
                .ForMember(x => x.RepresentationTitle,
                    b => b.MapFrom(c => c.Representation.Title))
                .ForMember(x => x.CourseStatusTitle, b => b.MapFrom(c => c.CourseStatusNavigation.Title)).ForMember(
                    x => x.CourseTitle,
                    b => b.MapFrom(c => c.Course.Title))
                .ForMember(x => x.AgeCategoryTitle, b => b.MapFrom(c => c.AgeCategoryNavigation.Title))
                .ForMember(x => x.ImplementationTypeTitle, b => b.MapFrom(c => c.ImplementationTypeNavigation.Title))
                .ForMember(x => x.CourseTypeTitle, b => b.MapFrom(c => c.CourseTypeNavigation.Title))
                .ForMember(x => x.RunTypeTitle, b => b.MapFrom(c => c.RunTypeNavigation.Title))
                .ForMember(x => x.CustomGenderTitle, b => b.MapFrom(c => c.CustomGenderNavigation.Title)).ForMember(
                    x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title))
                ;
            CreateMap<CoursePlanningEditModel, CoursePlanning>();

            CreateMap<CoursePlanning, CoursePlanningSimpleViewModel>();


            CreateMap<Representation, RepresentationEditModel>();

            CreateMap<Representation, RepresentationListViewModel>()
                .ForMember(x => x.EducationalCenterTitle,
                    b => b.MapFrom(c => c.EducationalCenter.Title))
                .ForMember(x => x.CityTitle,
                    b => b.MapFrom(c => c.City.Title))
                .ForMember(x => x.LicenseTypeTitle, b => b.MapFrom(c => c.LicenseTypeNavigation.Title))
                .ForMember(x => x.OwnershipTypeTitle, b => b.MapFrom(c => c.OwnershipTypeNavigation.Title))
                .ForMember(x => x.EstablishedLicenseTypeTitle,
                    b => b.MapFrom(c => c.EstablishedLicenseTypeNavigation.Title)).ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title))
                ;
            CreateMap<RepresentationEditModel, Representation>();

            CreateMap<Representation, RepresentationSimpleViewModel>();


            CreateMap<RepresentationPerson, RepresentationPersonEditModel>();

            CreateMap<RepresentationPerson, RepresentationPersonListViewModel>()
                .ForMember(x => x.RepresentationTitle,
                    b => b.MapFrom(c => c.Representation.Title))
                .ForMember(x => x.PersonTitle,
                    b => b.MapFrom(c => c.Person.Name))
                .ForMember(x => x.PostTitle,
                    b => b.MapFrom(c => c.Post.Title))
                .ForMember(x => x.CooperationTypeTitle, b => b.MapFrom(c => c.CooperationTypeNavigation.Title))
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));
            CreateMap<RepresentationPersonEditModel, RepresentationPerson>();

            CreateMap<RepresentationPerson, RepresentationPersonSimpleViewModel>();


            CreateMap<CourseCategory, CourseCategoryEditModel>().ForMember(x => x.EducationalCenterId,
                b => b.MapFrom(c => c.EducationalCenterMainCourseCategory.EducationalCenterId));

            CreateMap<CourseCategory, CourseCategoryListViewModel>()
                .ForMember(x => x.EducationalCenterMainCourseCategoryTitle,
                    b =>
                        b.MapFrom(c => c.EducationalCenterMainCourseCategory.MainCourseCategory.Title))
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));
            CreateMap<CourseCategoryEditModel, CourseCategory>();

            CreateMap<CourseCategory, CourseCategorySimpleViewModel>();


            CreateMap<EducationalCenter, EducationalCenterEditModel>();

            CreateMap<EducationalCenter, EducationalCenterListViewModel>()
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title))
                .ForMember(x => x.EstablishedLicenseTypeTitle,
                    b => b.MapFrom(c => c.EstablishedLicenseTypeNavigation.Title));
            CreateMap<EducationalCenterEditModel, EducationalCenter>();

            CreateMap<EducationalCenter, EducationalCenterSimpleViewModel>();


            CreateMap<AdditionalUserProp, AdditionalUserPropEditModel>();

            CreateMap<AdditionalUserProp, AdditionalUserPropListViewModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName))
                .ForMember(x => x.RepresentationTitle,
                    b => b.MapFrom(c => c.Representation.Title))
                ;
            CreateMap<AdditionalUserPropEditModel, AdditionalUserProp>();

            CreateMap<AdditionalUserProp, AdditionalUserPropSimpleViewModel>();


            CreateMap<MainCourseCategory, MainCourseCategoryEditModel>();

            CreateMap<MainCourseCategory, MainCourseCategoryListViewModel>()
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title))
                ;
            CreateMap<MainCourseCategoryEditModel, MainCourseCategory>();

            CreateMap<MainCourseCategory, MainCourseCategorySimpleViewModel>();


            CreateMap<EducationalCenterMainCourseCategory, EducationalCenterMainCourseCategoryEditModel>();

            CreateMap<EducationalCenterMainCourseCategory, EducationalCenterMainCourseCategoryListViewModel>()
                .ForMember(x => x.EducationalCenterTitle,
                    b => b.MapFrom(c => c.EducationalCenter.Title))
                .ForMember(x => x.MainCourseCategoryTitle,
                    b => b.MapFrom(c => c.MainCourseCategory.Title));
            CreateMap<EducationalCenterMainCourseCategoryEditModel, EducationalCenterMainCourseCategory>();

            CreateMap<EducationalCenterMainCourseCategory, EducationalCenterMainCourseCategorySimpleViewModel>()
                .ForMember(x => x.Title,
                    b => b.MapFrom(c => c.MainCourseCategory.Title))
                .ForMember(x => x.EducationalCenterId,
                    b => b.MapFrom(c => c.EducationalCenterId))
                .ForMember(x => x.MainCourseCategoryId,
                    b => b.MapFrom(c => c.MainCourseCategoryId));
        }
    }
}