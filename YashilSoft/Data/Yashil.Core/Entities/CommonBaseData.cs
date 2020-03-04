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
            CourseSkillTypeNavigation = new HashSet<Course>();
            CoursesPlanningAgeCategoryNavigation = new HashSet<CoursesPlanning>();
            CoursesPlanningCourceStatusNavigation = new HashSet<CoursesPlanning>();
            CoursesPlanningCourceTypeNavigation = new HashSet<CoursesPlanning>();
            CoursesPlanningCustomGenderNavigation = new HashSet<CoursesPlanning>();
            CoursesPlanningImplementaionTypeNavigation = new HashSet<CoursesPlanning>();
            CoursesPlanningRunTypeNavigation = new HashSet<CoursesPlanning>();
            InverseParent = new HashSet<CommonBaseData>();
            PersonEducationGradeNavigation = new HashSet<Person>();
            PersonGenderNavigation = new HashSet<Person>();
            RepresentationEstablishedLicenseTypeNavigation = new HashSet<Representation>();
            RepresentationLicenseTypeNavigation = new HashSet<Representation>();
            RepresentationOwnershipTypeNavigation = new HashSet<Representation>();
            RepresentationPerson = new HashSet<RepresentationPerson>();
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
        public virtual ICollection<Course> CourseSkillTypeNavigation { get; set; }
        public virtual ICollection<CoursesPlanning> CoursesPlanningAgeCategoryNavigation { get; set; }
        public virtual ICollection<CoursesPlanning> CoursesPlanningCourceStatusNavigation { get; set; }
        public virtual ICollection<CoursesPlanning> CoursesPlanningCourceTypeNavigation { get; set; }
        public virtual ICollection<CoursesPlanning> CoursesPlanningCustomGenderNavigation { get; set; }
        public virtual ICollection<CoursesPlanning> CoursesPlanningImplementaionTypeNavigation { get; set; }
        public virtual ICollection<CoursesPlanning> CoursesPlanningRunTypeNavigation { get; set; }
        public virtual ICollection<CommonBaseData> InverseParent { get; set; }
        public virtual ICollection<Person> PersonEducationGradeNavigation { get; set; }
        public virtual ICollection<Person> PersonGenderNavigation { get; set; }
        public virtual ICollection<Representation> RepresentationEstablishedLicenseTypeNavigation { get; set; }
        public virtual ICollection<Representation> RepresentationLicenseTypeNavigation { get; set; }
        public virtual ICollection<Representation> RepresentationOwnershipTypeNavigation { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPerson { get; set; }
    }
    }
