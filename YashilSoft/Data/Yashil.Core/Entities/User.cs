using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class User :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public User()
        {
            AccessLevelCreateByNavigation = new HashSet<AccessLevel>();
            AccessLevelModifyByNavigation = new HashSet<AccessLevel>();
            AdditionalUserPropCreateByNavigation = new HashSet<AdditionalUserProp>();
            AdditionalUserPropModifyByNavigation = new HashSet<AdditionalUserProp>();
            AppActionCreateByNavigation = new HashSet<AppAction>();
            AppActionModifyByNavigation = new HashSet<AppAction>();
            AppConfigCreateByNavigation = new HashSet<AppConfig>();
            AppConfigModifyByNavigation = new HashSet<AppConfig>();
            AppDocumentCreateByNavigation = new HashSet<AppDocument>();
            AppDocumentModifyByNavigation = new HashSet<AppDocument>();
            AppEntityAttributeCreateByNavigation = new HashSet<AppEntityAttribute>();
            AppEntityAttributeMappingCreateByNavigation = new HashSet<AppEntityAttributeMapping>();
            AppEntityAttributeMappingModifyByNavigation = new HashSet<AppEntityAttributeMapping>();
            AppEntityAttributeModifyByNavigation = new HashSet<AppEntityAttribute>();
            AppEntityAttributeValueCreateByNavigation = new HashSet<AppEntityAttributeValue>();
            AppEntityAttributeValueModifyByNavigation = new HashSet<AppEntityAttributeValue>();
            ApplicationCreateByNavigation = new HashSet<Application>();
            ApplicationModifyByNavigation = new HashSet<Application>();
            CityCreateByNavigation = new HashSet<City>();
            CityModifyByNavigation = new HashSet<City>();
            CommonBaseDataCreateByNavigation = new HashSet<CommonBaseData>();
            CommonBaseDataModifyByNavigation = new HashSet<CommonBaseData>();
            CommonBaseTypeCreateByNavigation = new HashSet<CommonBaseType>();
            CommonBaseTypeModifyByNavigation = new HashSet<CommonBaseType>();
            CourseCategoryCreateByNavigation = new HashSet<CourseCategory>();
            CourseCategoryModifyByNavigation = new HashSet<CourseCategory>();
            CourseCreateByNavigation = new HashSet<Course>();
            CourseModifyByNavigation = new HashSet<Course>();
            CoursePlanningCreateByNavigation = new HashSet<CoursePlanning>();
            CoursePlanningModifyByNavigation = new HashSet<CoursePlanning>();
            CoursePlanningScheduleCreateByNavigation = new HashSet<CoursePlanningSchedule>();
            CoursePlanningScheduleModifyByNavigation = new HashSet<CoursePlanningSchedule>();
            CoursePlanningStudentCreateByNavigation = new HashSet<CoursePlanningStudent>();
            CoursePlanningStudentModifyByNavigation = new HashSet<CoursePlanningStudent>();
            DashboardConnectionStringCreateByNavigation = new HashSet<DashboardConnectionString>();
            DashboardConnectionStringModifyByNavigation = new HashSet<DashboardConnectionString>();
            DashboardGroupDashboardCreateByNavigation = new HashSet<DashboardGroupDashboard>();
            DashboardGroupDashboardModifyByNavigation = new HashSet<DashboardGroupDashboard>();
            DashboardStoreCreateByNavigation = new HashSet<DashboardStore>();
            DashboardStoreModifyByNavigation = new HashSet<DashboardStore>();
            DocFormatCreateByNavigation = new HashSet<DocFormat>();
            DocFormatModifyByNavigation = new HashSet<DocFormat>();
            DocTypeCreateByNavigation = new HashSet<DocType>();
            DocTypeModifyByNavigation = new HashSet<DocType>();
            DocumentCategoryCreateByNavigation = new HashSet<DocumentCategory>();
            DocumentCategoryModifyByNavigation = new HashSet<DocumentCategory>();
            EducationalCenterCreateByNavigation = new HashSet<EducationalCenter>();
            EducationalCenterMainCourseCategoryCreateByNavigation = new HashSet<EducationalCenterMainCourseCategory>();
            EducationalCenterMainCourseCategoryModifyByNavigation = new HashSet<EducationalCenterMainCourseCategory>();
            EducationalCenterModifyByNavigation = new HashSet<EducationalCenter>();
            EvaluationStatusCreateByNavigation = new HashSet<EvaluationStatus>();
            EvaluationStatusModifyByNavigation = new HashSet<EvaluationStatus>();
            JobCreateByNavigation = new HashSet<Job>();
            JobModifyByNavigation = new HashSet<Job>();
            KeywordCreateByNavigation = new HashSet<Keyword>();
            KeywordModifyByNavigation = new HashSet<Keyword>();
            MainCourseCategoryCreateByNavigation = new HashSet<MainCourseCategory>();
            MainCourseCategoryModifyByNavigation = new HashSet<MainCourseCategory>();
            MainNewsCreateByNavigation = new HashSet<MainNews>();
            MainNewsModifyByNavigation = new HashSet<MainNews>();
            MenuCreateByNavigation = new HashSet<Menu>();
            MenuModifyByNavigation = new HashSet<Menu>();
            NewsKeywordCreateByNavigation = new HashSet<NewsKeyword>();
            NewsKeywordModifyByNavigation = new HashSet<NewsKeyword>();
            NewsStoreCreateByNavigation = new HashSet<NewsStore>();
            NewsStoreModifyByNavigation = new HashSet<NewsStore>();
            OrganizationCreateByNavigation = new HashSet<Organization>();
            OrganizationModifyByNavigation = new HashSet<Organization>();
            PersonBankAccountCreateByNavigation = new HashSet<PersonBankAccount>();
            PersonBankAccountModifyByNavigation = new HashSet<PersonBankAccount>();
            PersonCreateByNavigation = new HashSet<Person>();
            PersonModifyByNavigation = new HashSet<Person>();
            PostCreateByNavigation = new HashSet<Post>();
            PostModifyByNavigation = new HashSet<Post>();
            ReportConnectionStringCreateByNavigation = new HashSet<ReportConnectionString>();
            ReportConnectionStringModifyByNavigation = new HashSet<ReportConnectionString>();
            ReportGroupReportCreateByNavigation = new HashSet<ReportGroupReport>();
            ReportGroupReportModifyByNavigation = new HashSet<ReportGroupReport>();
            ReportStoreCreateByNavigation = new HashSet<ReportStore>();
            ReportStoreModifyByNavigation = new HashSet<ReportStore>();
            RepresentationCourseCategoryCreateByNavigation = new HashSet<RepresentationCourseCategory>();
            RepresentationCourseCategoryModifyByNavigation = new HashSet<RepresentationCourseCategory>();
            RepresentationCreateByNavigation = new HashSet<Representation>();
            RepresentationEstablishedLicenseTypeCreateByNavigation = new HashSet<RepresentationEstablishedLicenseType>();
            RepresentationEstablishedLicenseTypeModifyByNavigation = new HashSet<RepresentationEstablishedLicenseType>();
            RepresentationModifyByNavigation = new HashSet<Representation>();
            RepresentationPersonCreateByNavigation = new HashSet<RepresentationPerson>();
            RepresentationPersonModifyByNavigation = new HashSet<RepresentationPerson>();
            RepresentationTeacherCreateByNavigation = new HashSet<RepresentationTeacher>();
            RepresentationTeacherModifyByNavigation = new HashSet<RepresentationTeacher>();
            ResourceCreateByNavigation = new HashSet<Resource>();
            ResourceModifyByNavigation = new HashSet<Resource>();
            RoleCreateByNavigation = new HashSet<Role>();
            RoleDashboardCreateByNavigation = new HashSet<RoleDashboard>();
            RoleDashboardModifyByNavigation = new HashSet<RoleDashboard>();
            RoleModifyByNavigation = new HashSet<Role>();
            RoleReportCreateByNavigation = new HashSet<RoleReport>();
            RoleReportModifyByNavigation = new HashSet<RoleReport>();
            ServiceCreateByNavigation = new HashSet<Service>();
            ServiceModifyByNavigation = new HashSet<Service>();
            UserDashboardCreateByNavigation = new HashSet<UserDashboard>();
            UserDashboardModifyByNavigation = new HashSet<UserDashboard>();
            UserDashboardUser = new HashSet<UserDashboard>();
            UserReportCreateByNavigation = new HashSet<UserReport>();
            UserReportModifyByNavigation = new HashSet<UserReport>();
            UserReportUser = new HashSet<UserReport>();
            UserRoleCreateByNavigation = new HashSet<UserRole>();
            UserRoleModifyByNavigation = new HashSet<UserRole>();
            UserRoleUser = new HashSet<UserRole>();
            YashilDataProviderCreateByNavigation = new HashSet<YashilDataProvider>();
            YashilDataProviderModifyByNavigation = new HashSet<YashilDataProvider>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public bool? IsActive { get; set; }
        public string MobileNumber { get; set; }
        public int OrganizationId { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Address { get; set; }
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
        public virtual Organization CreatorOrganization { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual AdditionalUserProp AdditionalUserPropUser { get; set; }
        public virtual ICollection<AccessLevel> AccessLevelCreateByNavigation { get; set; }
        public virtual ICollection<AccessLevel> AccessLevelModifyByNavigation { get; set; }
        public virtual ICollection<AdditionalUserProp> AdditionalUserPropCreateByNavigation { get; set; }
        public virtual ICollection<AdditionalUserProp> AdditionalUserPropModifyByNavigation { get; set; }
        public virtual ICollection<AppAction> AppActionCreateByNavigation { get; set; }
        public virtual ICollection<AppAction> AppActionModifyByNavigation { get; set; }
        public virtual ICollection<AppConfig> AppConfigCreateByNavigation { get; set; }
        public virtual ICollection<AppConfig> AppConfigModifyByNavigation { get; set; }
        public virtual ICollection<AppDocument> AppDocumentCreateByNavigation { get; set; }
        public virtual ICollection<AppDocument> AppDocumentModifyByNavigation { get; set; }
        public virtual ICollection<AppEntityAttribute> AppEntityAttributeCreateByNavigation { get; set; }
        public virtual ICollection<AppEntityAttributeMapping> AppEntityAttributeMappingCreateByNavigation { get; set; }
        public virtual ICollection<AppEntityAttributeMapping> AppEntityAttributeMappingModifyByNavigation { get; set; }
        public virtual ICollection<AppEntityAttribute> AppEntityAttributeModifyByNavigation { get; set; }
        public virtual ICollection<AppEntityAttributeValue> AppEntityAttributeValueCreateByNavigation { get; set; }
        public virtual ICollection<AppEntityAttributeValue> AppEntityAttributeValueModifyByNavigation { get; set; }
        public virtual ICollection<Application> ApplicationCreateByNavigation { get; set; }
        public virtual ICollection<Application> ApplicationModifyByNavigation { get; set; }
        public virtual ICollection<City> CityCreateByNavigation { get; set; }
        public virtual ICollection<City> CityModifyByNavigation { get; set; }
        public virtual ICollection<CommonBaseData> CommonBaseDataCreateByNavigation { get; set; }
        public virtual ICollection<CommonBaseData> CommonBaseDataModifyByNavigation { get; set; }
        public virtual ICollection<CommonBaseType> CommonBaseTypeCreateByNavigation { get; set; }
        public virtual ICollection<CommonBaseType> CommonBaseTypeModifyByNavigation { get; set; }
        public virtual ICollection<CourseCategory> CourseCategoryCreateByNavigation { get; set; }
        public virtual ICollection<CourseCategory> CourseCategoryModifyByNavigation { get; set; }
        public virtual ICollection<Course> CourseCreateByNavigation { get; set; }
        public virtual ICollection<Course> CourseModifyByNavigation { get; set; }
        public virtual ICollection<CoursePlanning> CoursePlanningCreateByNavigation { get; set; }
        public virtual ICollection<CoursePlanning> CoursePlanningModifyByNavigation { get; set; }
        public virtual ICollection<CoursePlanningSchedule> CoursePlanningScheduleCreateByNavigation { get; set; }
        public virtual ICollection<CoursePlanningSchedule> CoursePlanningScheduleModifyByNavigation { get; set; }
        public virtual ICollection<CoursePlanningStudent> CoursePlanningStudentCreateByNavigation { get; set; }
        public virtual ICollection<CoursePlanningStudent> CoursePlanningStudentModifyByNavigation { get; set; }
        public virtual ICollection<DashboardConnectionString> DashboardConnectionStringCreateByNavigation { get; set; }
        public virtual ICollection<DashboardConnectionString> DashboardConnectionStringModifyByNavigation { get; set; }
        public virtual ICollection<DashboardGroupDashboard> DashboardGroupDashboardCreateByNavigation { get; set; }
        public virtual ICollection<DashboardGroupDashboard> DashboardGroupDashboardModifyByNavigation { get; set; }
        public virtual ICollection<DashboardStore> DashboardStoreCreateByNavigation { get; set; }
        public virtual ICollection<DashboardStore> DashboardStoreModifyByNavigation { get; set; }
        public virtual ICollection<DocFormat> DocFormatCreateByNavigation { get; set; }
        public virtual ICollection<DocFormat> DocFormatModifyByNavigation { get; set; }
        public virtual ICollection<DocType> DocTypeCreateByNavigation { get; set; }
        public virtual ICollection<DocType> DocTypeModifyByNavigation { get; set; }
        public virtual ICollection<DocumentCategory> DocumentCategoryCreateByNavigation { get; set; }
        public virtual ICollection<DocumentCategory> DocumentCategoryModifyByNavigation { get; set; }
        public virtual ICollection<EducationalCenter> EducationalCenterCreateByNavigation { get; set; }
        public virtual ICollection<EducationalCenterMainCourseCategory> EducationalCenterMainCourseCategoryCreateByNavigation { get; set; }
        public virtual ICollection<EducationalCenterMainCourseCategory> EducationalCenterMainCourseCategoryModifyByNavigation { get; set; }
        public virtual ICollection<EducationalCenter> EducationalCenterModifyByNavigation { get; set; }
        public virtual ICollection<EvaluationStatus> EvaluationStatusCreateByNavigation { get; set; }
        public virtual ICollection<EvaluationStatus> EvaluationStatusModifyByNavigation { get; set; }
        public virtual ICollection<Job> JobCreateByNavigation { get; set; }
        public virtual ICollection<Job> JobModifyByNavigation { get; set; }
        public virtual ICollection<Keyword> KeywordCreateByNavigation { get; set; }
        public virtual ICollection<Keyword> KeywordModifyByNavigation { get; set; }
        public virtual ICollection<MainCourseCategory> MainCourseCategoryCreateByNavigation { get; set; }
        public virtual ICollection<MainCourseCategory> MainCourseCategoryModifyByNavigation { get; set; }
        public virtual ICollection<MainNews> MainNewsCreateByNavigation { get; set; }
        public virtual ICollection<MainNews> MainNewsModifyByNavigation { get; set; }
        public virtual ICollection<Menu> MenuCreateByNavigation { get; set; }
        public virtual ICollection<Menu> MenuModifyByNavigation { get; set; }
        public virtual ICollection<NewsKeyword> NewsKeywordCreateByNavigation { get; set; }
        public virtual ICollection<NewsKeyword> NewsKeywordModifyByNavigation { get; set; }
        public virtual ICollection<NewsStore> NewsStoreCreateByNavigation { get; set; }
        public virtual ICollection<NewsStore> NewsStoreModifyByNavigation { get; set; }
        public virtual ICollection<Organization> OrganizationCreateByNavigation { get; set; }
        public virtual ICollection<Organization> OrganizationModifyByNavigation { get; set; }
        public virtual ICollection<PersonBankAccount> PersonBankAccountCreateByNavigation { get; set; }
        public virtual ICollection<PersonBankAccount> PersonBankAccountModifyByNavigation { get; set; }
        public virtual ICollection<Person> PersonCreateByNavigation { get; set; }
        public virtual ICollection<Person> PersonModifyByNavigation { get; set; }
        public virtual ICollection<Post> PostCreateByNavigation { get; set; }
        public virtual ICollection<Post> PostModifyByNavigation { get; set; }
        public virtual ICollection<ReportConnectionString> ReportConnectionStringCreateByNavigation { get; set; }
        public virtual ICollection<ReportConnectionString> ReportConnectionStringModifyByNavigation { get; set; }
        public virtual ICollection<ReportGroupReport> ReportGroupReportCreateByNavigation { get; set; }
        public virtual ICollection<ReportGroupReport> ReportGroupReportModifyByNavigation { get; set; }
        public virtual ICollection<ReportStore> ReportStoreCreateByNavigation { get; set; }
        public virtual ICollection<ReportStore> ReportStoreModifyByNavigation { get; set; }
        public virtual ICollection<RepresentationCourseCategory> RepresentationCourseCategoryCreateByNavigation { get; set; }
        public virtual ICollection<RepresentationCourseCategory> RepresentationCourseCategoryModifyByNavigation { get; set; }
        public virtual ICollection<Representation> RepresentationCreateByNavigation { get; set; }
        public virtual ICollection<RepresentationEstablishedLicenseType> RepresentationEstablishedLicenseTypeCreateByNavigation { get; set; }
        public virtual ICollection<RepresentationEstablishedLicenseType> RepresentationEstablishedLicenseTypeModifyByNavigation { get; set; }
        public virtual ICollection<Representation> RepresentationModifyByNavigation { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPersonCreateByNavigation { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPersonModifyByNavigation { get; set; }
        public virtual ICollection<RepresentationTeacher> RepresentationTeacherCreateByNavigation { get; set; }
        public virtual ICollection<RepresentationTeacher> RepresentationTeacherModifyByNavigation { get; set; }
        public virtual ICollection<Resource> ResourceCreateByNavigation { get; set; }
        public virtual ICollection<Resource> ResourceModifyByNavigation { get; set; }
        public virtual ICollection<Role> RoleCreateByNavigation { get; set; }
        public virtual ICollection<RoleDashboard> RoleDashboardCreateByNavigation { get; set; }
        public virtual ICollection<RoleDashboard> RoleDashboardModifyByNavigation { get; set; }
        public virtual ICollection<Role> RoleModifyByNavigation { get; set; }
        public virtual ICollection<RoleReport> RoleReportCreateByNavigation { get; set; }
        public virtual ICollection<RoleReport> RoleReportModifyByNavigation { get; set; }
        public virtual ICollection<Service> ServiceCreateByNavigation { get; set; }
        public virtual ICollection<Service> ServiceModifyByNavigation { get; set; }
        public virtual ICollection<UserDashboard> UserDashboardCreateByNavigation { get; set; }
        public virtual ICollection<UserDashboard> UserDashboardModifyByNavigation { get; set; }
        public virtual ICollection<UserDashboard> UserDashboardUser { get; set; }
        public virtual ICollection<UserReport> UserReportCreateByNavigation { get; set; }
        public virtual ICollection<UserReport> UserReportModifyByNavigation { get; set; }
        public virtual ICollection<UserReport> UserReportUser { get; set; }
        public virtual ICollection<UserRole> UserRoleCreateByNavigation { get; set; }
        public virtual ICollection<UserRole> UserRoleModifyByNavigation { get; set; }
        public virtual ICollection<UserRole> UserRoleUser { get; set; }
        public virtual ICollection<YashilDataProvider> YashilDataProviderCreateByNavigation { get; set; }
        public virtual ICollection<YashilDataProvider> YashilDataProviderModifyByNavigation { get; set; }
    }
    }
