using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class Organization :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public Organization()
        {
            AccessLevel = new HashSet<AccessLevel>();
            AdditionalUserProp = new HashSet<AdditionalUserProp>();
            AppConfig = new HashSet<AppConfig>();
            AppDocument = new HashSet<AppDocument>();
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
            DashboardGroup = new HashSet<DashboardGroup>();
            DashboardStore = new HashSet<DashboardStore>();
            DocType = new HashSet<DocType>();
            DocumentCategory = new HashSet<DocumentCategory>();
            EducationalCenter = new HashSet<EducationalCenter>();
            EducationalCenterMainCourseCategory = new HashSet<EducationalCenterMainCourseCategory>();
            EvaluationStatus = new HashSet<EvaluationStatus>();
            InverseParent = new HashSet<Organization>();
            Job = new HashSet<Job>();
            Keyword = new HashSet<Keyword>();
            MainCourseCategory = new HashSet<MainCourseCategory>();
            MainNews = new HashSet<MainNews>();
            NewsKeyword = new HashSet<NewsKeyword>();
            NewsStore = new HashSet<NewsStore>();
            Person = new HashSet<Person>();
            PersonBankAccount = new HashSet<PersonBankAccount>();
            Post = new HashSet<Post>();
            ReportGroup = new HashSet<ReportGroup>();
            ReportStore = new HashSet<ReportStore>();
            Representation = new HashSet<Representation>();
            RepresentationCourseCategory = new HashSet<RepresentationCourseCategory>();
            RepresentationEstablishedLicenseType = new HashSet<RepresentationEstablishedLicenseType>();
            RepresentationPerson = new HashSet<RepresentationPerson>();
            RepresentationTeacher = new HashSet<RepresentationTeacher>();
            Role = new HashSet<Role>();
            Service = new HashSet<Service>();
            UserCreatorOrganization = new HashSet<User>();
            UserOrganization = new HashSet<User>();
            YashilConnectionString = new HashSet<YashilConnectionString>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int? ParentId { get; set; }
        public long? UniqueId { get; set; }
        public string CodePath { get; set; }
        public int? Type { get; set; }
        public int? ProvinceId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual Organization Parent { get; set; }
        public virtual ICollection<AccessLevel> AccessLevel { get; set; }
        public virtual ICollection<AdditionalUserProp> AdditionalUserProp { get; set; }
        public virtual ICollection<AppConfig> AppConfig { get; set; }
        public virtual ICollection<AppDocument> AppDocument { get; set; }
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
        public virtual ICollection<DashboardGroup> DashboardGroup { get; set; }
        public virtual ICollection<DashboardStore> DashboardStore { get; set; }
        public virtual ICollection<DocType> DocType { get; set; }
        public virtual ICollection<DocumentCategory> DocumentCategory { get; set; }
        public virtual ICollection<EducationalCenter> EducationalCenter { get; set; }
        public virtual ICollection<EducationalCenterMainCourseCategory> EducationalCenterMainCourseCategory { get; set; }
        public virtual ICollection<EvaluationStatus> EvaluationStatus { get; set; }
        public virtual ICollection<Organization> InverseParent { get; set; }
        public virtual ICollection<Job> Job { get; set; }
        public virtual ICollection<Keyword> Keyword { get; set; }
        public virtual ICollection<MainCourseCategory> MainCourseCategory { get; set; }
        public virtual ICollection<MainNews> MainNews { get; set; }
        public virtual ICollection<NewsKeyword> NewsKeyword { get; set; }
        public virtual ICollection<NewsStore> NewsStore { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<PersonBankAccount> PersonBankAccount { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<ReportGroup> ReportGroup { get; set; }
        public virtual ICollection<ReportStore> ReportStore { get; set; }
        public virtual ICollection<Representation> Representation { get; set; }
        public virtual ICollection<RepresentationCourseCategory> RepresentationCourseCategory { get; set; }
        public virtual ICollection<RepresentationEstablishedLicenseType> RepresentationEstablishedLicenseType { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPerson { get; set; }
        public virtual ICollection<RepresentationTeacher> RepresentationTeacher { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<Service> Service { get; set; }
        public virtual ICollection<User> UserCreatorOrganization { get; set; }
        public virtual ICollection<User> UserOrganization { get; set; }
        public virtual ICollection<YashilConnectionString> YashilConnectionString { get; set; }
    }
    }
