using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class CommonBaseData :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public CommonBaseData()
        {
            AppEntityAttributeMapping = new HashSet<AppEntityAttributeMapping>();
            CityCountryDivisionTypeNavigation = new HashSet<City>();
            CityCustomCategoryNavigation = new HashSet<City>();
            CourseCertificateTypeNavigation = new HashSet<Course>();
            CourseEvaluationMethodNavigation = new HashSet<Course>();
            CoursePlanningAgeCategoryNavigation = new HashSet<CoursePlanning>();
            CoursePlanningCourseStatusNavigation = new HashSet<CoursePlanning>();
            CoursePlanningCourseTypeNavigation = new HashSet<CoursePlanning>();
            CoursePlanningCustomGenderNavigation = new HashSet<CoursePlanning>();
            CoursePlanningImplementationTypeNavigation = new HashSet<CoursePlanning>();
            CoursePlanningRunTypeNavigation = new HashSet<CoursePlanning>();
            CoursePlanningStudent = new HashSet<CoursePlanningStudent>();
            CourseSkillTypeNavigation = new HashSet<Course>();
            EducationalCenter = new HashSet<EducationalCenter>();
            InverseParent = new HashSet<CommonBaseData>();
            Keyword = new HashSet<Keyword>();
            NewsStoreLanguageNavigation = new HashSet<NewsStore>();
            NewsStoreNewsTypeNavigation = new HashSet<NewsStore>();
            PersonBankAccount = new HashSet<PersonBankAccount>();
            PersonEducationGradeNavigation = new HashSet<Person>();
            PersonGenderNavigation = new HashSet<Person>();
            RepresentationEstablishedLicenseType = new HashSet<RepresentationEstablishedLicenseType>();
            RepresentationLicenseTypeNavigation = new HashSet<Representation>();
            RepresentationOwnershipTypeNavigation = new HashSet<Representation>();
            RepresentationTeacher = new HashSet<RepresentationTeacher>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public int Value { get; set; }
        public string ExtendedProps { get; set; }
        public int CommonBaseTypeId { get; set; }
        public bool IsSystemProp { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public int AccessLevelId { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }

        public virtual AccessLevel AccessLevel { get; set; }
        public virtual Application Application { get; set; }
        public virtual CommonBaseType CommonBaseType { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual CommonBaseData Parent { get; set; }
        public virtual ICollection<AppEntityAttributeMapping> AppEntityAttributeMapping { get; set; }
        public virtual ICollection<City> CityCountryDivisionTypeNavigation { get; set; }
        public virtual ICollection<City> CityCustomCategoryNavigation { get; set; }
        public virtual ICollection<Course> CourseCertificateTypeNavigation { get; set; }
        public virtual ICollection<Course> CourseEvaluationMethodNavigation { get; set; }
        public virtual ICollection<CoursePlanning> CoursePlanningAgeCategoryNavigation { get; set; }
        public virtual ICollection<CoursePlanning> CoursePlanningCourseStatusNavigation { get; set; }
        public virtual ICollection<CoursePlanning> CoursePlanningCourseTypeNavigation { get; set; }
        public virtual ICollection<CoursePlanning> CoursePlanningCustomGenderNavigation { get; set; }
        public virtual ICollection<CoursePlanning> CoursePlanningImplementationTypeNavigation { get; set; }
        public virtual ICollection<CoursePlanning> CoursePlanningRunTypeNavigation { get; set; }
        public virtual ICollection<CoursePlanningStudent> CoursePlanningStudent { get; set; }
        public virtual ICollection<Course> CourseSkillTypeNavigation { get; set; }
        public virtual ICollection<EducationalCenter> EducationalCenter { get; set; }
        public virtual ICollection<CommonBaseData> InverseParent { get; set; }
        public virtual ICollection<Keyword> Keyword { get; set; }
        public virtual ICollection<NewsStore> NewsStoreLanguageNavigation { get; set; }
        public virtual ICollection<NewsStore> NewsStoreNewsTypeNavigation { get; set; }
        public virtual ICollection<PersonBankAccount> PersonBankAccount { get; set; }
        public virtual ICollection<Person> PersonEducationGradeNavigation { get; set; }
        public virtual ICollection<Person> PersonGenderNavigation { get; set; }
        public virtual ICollection<RepresentationEstablishedLicenseType> RepresentationEstablishedLicenseType { get; set; }
        public virtual ICollection<Representation> RepresentationLicenseTypeNavigation { get; set; }
        public virtual ICollection<Representation> RepresentationOwnershipTypeNavigation { get; set; }
        public virtual ICollection<RepresentationTeacher> RepresentationTeacher { get; set; }
    }
    }
