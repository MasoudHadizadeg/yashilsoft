using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class AccessLevel :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public AccessLevel()
        {
            AppEntityAttribute = new HashSet<AppEntityAttribute>();
            AppEntityAttributeMapping = new HashSet<AppEntityAttributeMapping>();
            AppEntityAttributeValue = new HashSet<AppEntityAttributeValue>();
            CommonBaseData = new HashSet<CommonBaseData>();
            CommonBaseType = new HashSet<CommonBaseType>();
            Course = new HashSet<Course>();
            CourseCategory = new HashSet<CourseCategory>();
            CoursePlanning = new HashSet<CoursePlanning>();
            CoursePlanningSchedule = new HashSet<CoursePlanningSchedule>();
            CoursePlanningStudent = new HashSet<CoursePlanningStudent>();
            DashboardStore = new HashSet<DashboardStore>();
            EducationalCenter = new HashSet<EducationalCenter>();
            EvaluationStatus = new HashSet<EvaluationStatus>();
            Job = new HashSet<Job>();
            Keyword = new HashSet<Keyword>();
            MainCourseCategory = new HashSet<MainCourseCategory>();
            NewsKeyword = new HashSet<NewsKeyword>();
            NewsStore = new HashSet<NewsStore>();
            Person = new HashSet<Person>();
            PersonBankAccount = new HashSet<PersonBankAccount>();
            Post = new HashSet<Post>();
            ReportStore = new HashSet<ReportStore>();
            Representation = new HashSet<Representation>();
            RepresentationCourseCategory = new HashSet<RepresentationCourseCategory>();
            RepresentationEstablishedLicenseType = new HashSet<RepresentationEstablishedLicenseType>();
            RepresentationPerson = new HashSet<RepresentationPerson>();
            RepresentationTeacher = new HashSet<RepresentationTeacher>();
            Service = new HashSet<Service>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int LevelValue { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }
        public int ApplicationId { get; set; }

        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<AppEntityAttribute> AppEntityAttribute { get; set; }
        public virtual ICollection<AppEntityAttributeMapping> AppEntityAttributeMapping { get; set; }
        public virtual ICollection<AppEntityAttributeValue> AppEntityAttributeValue { get; set; }
        public virtual ICollection<CommonBaseData> CommonBaseData { get; set; }
        public virtual ICollection<CommonBaseType> CommonBaseType { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<CourseCategory> CourseCategory { get; set; }
        public virtual ICollection<CoursePlanning> CoursePlanning { get; set; }
        public virtual ICollection<CoursePlanningSchedule> CoursePlanningSchedule { get; set; }
        public virtual ICollection<CoursePlanningStudent> CoursePlanningStudent { get; set; }
        public virtual ICollection<DashboardStore> DashboardStore { get; set; }
        public virtual ICollection<EducationalCenter> EducationalCenter { get; set; }
        public virtual ICollection<EvaluationStatus> EvaluationStatus { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<Keyword> Keyword { get; set; }
        public virtual ICollection<MainCourseCategory> MainCourseCategory { get; set; }
        public virtual ICollection<NewsKeyword> NewsKeyword { get; set; }
        public virtual ICollection<NewsStore> NewsStore { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<PersonBankAccount> PersonBankAccount { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<ReportStore> ReportStore { get; set; }
        public virtual ICollection<Representation> Representation { get; set; }
        public virtual ICollection<RepresentationCourseCategory> RepresentationCourseCategory { get; set; }
        public virtual ICollection<RepresentationEstablishedLicenseType> RepresentationEstablishedLicenseType { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPerson { get; set; }
        public virtual ICollection<RepresentationTeacher> RepresentationTeacher { get; set; }
        public virtual ICollection<Service> Service { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
    }
