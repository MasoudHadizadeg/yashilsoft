
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

            CreateMap<CoursesPlanningStudent, CoursesPlanningStudentEditModel>()
                                .ForMember(x => x.CoursesPlanningTitle,
                b => b.MapFrom(c => c.CoursesPlanning.Course.Title))
                            .ForMember(x => x.PersonTitle,
                b => b.MapFrom(c => c.Person.Name))
                            .ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;


            CreateMap<CoursesPlanningStudent, CoursesPlanningStudentListViewModel>()
                                .ForMember(x => x.CoursesPlanningTitle,
                b => b.MapFrom(c => c.CoursesPlanning.Course.Title))
                            .ForMember(x => x.PersonTitle,
                b => b.MapFrom(c => c.Person.Name))
                            .ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;
            CreateMap<CoursesPlanningStudentEditModel, CoursesPlanningStudent>();

            CreateMap<CoursesPlanningStudent, CoursesPlanningStudentSimpleViewModel>();


            CreateMap<Course, CourseEditModel>()
                                .ForMember(x => x.CourseCategoryTitle,
                b => b.MapFrom(c => c.CourseCategory.Title))
                            .ForMember(x => x.EducationalCenterTitle,
                b => b.MapFrom(c => c.EducationalCenter.Title))
        .ForMember(x => x.SkillTypeTitle, b => b.MapFrom(c => c.SkillTypeNavigation.Title)).ForMember(x => x.CertificateTypeTitle, b => b.MapFrom(c => c.CertificateTypeNavigation.Title)).ForMember(x => x.EvaluationMethodTitle, b => b.MapFrom(c => c.EvaluationMethodNavigation.Title)).ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;


            CreateMap<Course, CourseListViewModel>()
                                .ForMember(x => x.CourseCategoryTitle,
                b => b.MapFrom(c => c.CourseCategory.Title))
                            .ForMember(x => x.EducationalCenterTitle,
                b => b.MapFrom(c => c.EducationalCenter.Title))
        .ForMember(x => x.SkillTypeTitle, b => b.MapFrom(c => c.SkillTypeNavigation.Title)).ForMember(x => x.CertificateTypeTitle, b => b.MapFrom(c => c.CertificateTypeNavigation.Title)).ForMember(x => x.EvaluationMethodTitle, b => b.MapFrom(c => c.EvaluationMethodNavigation.Title)).ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;
            CreateMap<CourseEditModel, Course>();

            CreateMap<Course, CourseSimpleViewModel>();


            CreateMap<CoursesPlanning, CoursesPlanningEditModel>()
                                .ForMember(x => x.RepresentationTitle,
                b => b.MapFrom(c => c.Representation.Title))
        .ForMember(x => x.CourceStatusTitle, b => b.MapFrom(c => c.CourceStatusNavigation.Title)).ForMember(x => x.CourseTitle,
                b => b.MapFrom(c => c.Course.Title))
        .ForMember(x => x.AgeCategoryTitle, b => b.MapFrom(c => c.AgeCategoryNavigation.Title)).ForMember(x => x.ImplementaionTypeTitle, b => b.MapFrom(c => c.ImplementaionTypeNavigation.Title)).ForMember(x => x.CourceTypeTitle, b => b.MapFrom(c => c.CourceTypeNavigation.Title)).ForMember(x => x.RunTypeTitle, b => b.MapFrom(c => c.RunTypeNavigation.Title)).ForMember(x => x.CustomGenderTitle, b => b.MapFrom(c => c.CustomGenderNavigation.Title)).ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;


            CreateMap<CoursesPlanning, CoursesPlanningListViewModel>()
                                .ForMember(x => x.RepresentationTitle,
                b => b.MapFrom(c => c.Representation.Title))
        .ForMember(x => x.CourceStatusTitle, b => b.MapFrom(c => c.CourceStatusNavigation.Title)).ForMember(x => x.CourseTitle,
                b => b.MapFrom(c => c.Course.Title))
        .ForMember(x => x.AgeCategoryTitle, b => b.MapFrom(c => c.AgeCategoryNavigation.Title)).ForMember(x => x.ImplementaionTypeTitle, b => b.MapFrom(c => c.ImplementaionTypeNavigation.Title)).ForMember(x => x.CourceTypeTitle, b => b.MapFrom(c => c.CourceTypeNavigation.Title)).ForMember(x => x.RunTypeTitle, b => b.MapFrom(c => c.RunTypeNavigation.Title)).ForMember(x => x.CustomGenderTitle, b => b.MapFrom(c => c.CustomGenderNavigation.Title)).ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;
            CreateMap<CoursesPlanningEditModel, CoursesPlanning>();

            CreateMap<CoursesPlanning, CoursesPlanningSimpleViewModel>();


            CreateMap<Representation, RepresentationEditModel>()
                                .ForMember(x => x.EducationalCenterTitle,
                b => b.MapFrom(c => c.EducationalCenter.Title))
                            .ForMember(x => x.CityTitle,
                b => b.MapFrom(c => c.City.Title))
        .ForMember(x => x.LicenseTypeTitle, b => b.MapFrom(c => c.LicenseTypeNavigation.Title)).ForMember(x => x.OwnershipTypeTitle, b => b.MapFrom(c => c.OwnershipTypeNavigation.Title)).ForMember(x => x.EstablishedLicenseTypeTitle, b => b.MapFrom(c => c.EstablishedLicenseTypeNavigation.Title)).ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;


            CreateMap<Representation, RepresentationListViewModel>()
                                .ForMember(x => x.EducationalCenterTitle,
                b => b.MapFrom(c => c.EducationalCenter.Title))
                            .ForMember(x => x.CityTitle,
                b => b.MapFrom(c => c.City.Title))
        .ForMember(x => x.LicenseTypeTitle, b => b.MapFrom(c => c.LicenseTypeNavigation.Title)).ForMember(x => x.OwnershipTypeTitle, b => b.MapFrom(c => c.OwnershipTypeNavigation.Title)).ForMember(x => x.EstablishedLicenseTypeTitle, b => b.MapFrom(c => c.EstablishedLicenseTypeNavigation.Title)).ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;
            CreateMap<RepresentationEditModel, Representation>();

            CreateMap<Representation, RepresentationSimpleViewModel>();


            CreateMap<RepresentationPerson, RepresentationPersonEditModel>()
                                .ForMember(x => x.RepresentationTitle,
                b => b.MapFrom(c => c.Representation.Title))
                            .ForMember(x => x.PersonTitle,
                b => b.MapFrom(c => c.Person.Name))
                            .ForMember(x => x.PostTitle,
                b => b.MapFrom(c => c.Post.Title))
        .ForMember(x => x.CooperationTypeTitle, b => b.MapFrom(c => c.CooperationTypeNavigation.Title)).ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;


            CreateMap<RepresentationPerson, RepresentationPersonListViewModel>()
                                .ForMember(x => x.RepresentationTitle,
                b => b.MapFrom(c => c.Representation.Title))
                            .ForMember(x => x.PersonTitle,
                b => b.MapFrom(c => c.Person.Name))
                            .ForMember(x => x.PostTitle,
                b => b.MapFrom(c => c.Post.Title))
        .ForMember(x => x.CooperationTypeTitle, b => b.MapFrom(c => c.CooperationTypeNavigation.Title)).ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;
            CreateMap<RepresentationPersonEditModel, RepresentationPerson>();

            CreateMap<RepresentationPerson, RepresentationPersonSimpleViewModel>();


            CreateMap<CourseCategory, CourseCategoryEditModel>()
                                .ForMember(x => x.EducationalCenterTitle,
                b => b.MapFrom(c => c.EducationalCenter.Title))
                            .ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;


            CreateMap<CourseCategory, CourseCategoryListViewModel>()
                                .ForMember(x => x.EducationalCenterTitle,
                b => b.MapFrom(c => c.EducationalCenter.Title))
                            .ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;
            CreateMap<CourseCategoryEditModel, CourseCategory>();

            CreateMap<CourseCategory, CourseCategorySimpleViewModel>();


            CreateMap<EducationalCenter, EducationalCenterEditModel>()
                                .ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;


            CreateMap<EducationalCenter, EducationalCenterListViewModel>()
                                .ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;
            CreateMap<EducationalCenterEditModel, EducationalCenter>();

            CreateMap<EducationalCenter, EducationalCenterSimpleViewModel>();

        }
    }
}
