using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class User
    {
        public User()
        {
            AccessLevelCreateByNavigation = new HashSet<AccessLevel>();
            AccessLevelModifyByNavigation = new HashSet<AccessLevel>();
            AppActionCreateByNavigation = new HashSet<AppAction>();
            AppActionModifyByNavigation = new HashSet<AppAction>();
            AppConfigCreateByNavigation = new HashSet<AppConfig>();
            AppConfigModifyByNavigation = new HashSet<AppConfig>();
            AppDocumentCreateByNavigation = new HashSet<AppDocument>();
            AppDocumentModifyByNavigation = new HashSet<AppDocument>();
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
            CoursesPlanningCreateByNavigation = new HashSet<CoursesPlanning>();
            CoursesPlanningModifyByNavigation = new HashSet<CoursesPlanning>();
            CoursesPlanningStudentCreateByNavigation = new HashSet<CoursesPlanningStudent>();
            CoursesPlanningStudentModifyByNavigation = new HashSet<CoursesPlanningStudent>();
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
            EducationalCenterModifyByNavigation = new HashSet<EducationalCenter>();
            HrCreateByNavigation = new HashSet<Hr>();
            HrModifyByNavigation = new HashSet<Hr>();
            MenuCreateByNavigation = new HashSet<Menu>();
            MenuModifyByNavigation = new HashSet<Menu>();
            OrganizationCreateByNavigation = new HashSet<Organization>();
            OrganizationModifyByNavigation = new HashSet<Organization>();
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
            RepresentationCreateByNavigation = new HashSet<Representation>();
            RepresentationModifyByNavigation = new HashSet<Representation>();
            RepresentationPersonCreateByNavigation = new HashSet<RepresentationPerson>();
            RepresentationPersonModifyByNavigation = new HashSet<RepresentationPerson>();
            ResourceCreateByNavigation = new HashSet<Resource>();
            ResourceModifyByNavigation = new HashSet<Resource>();
            RoleCreateByNavigation = new HashSet<Role>();
            RoleDashboardCreateByNavigation = new HashSet<RoleDashboard>();
            RoleDashboardModifyByNavigation = new HashSet<RoleDashboard>();
            RoleModifyByNavigation = new HashSet<Role>();
            RoleReportCreateByNavigation = new HashSet<RoleReport>();
            RoleReportModifyByNavigation = new HashSet<RoleReport>();
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
        public virtual ICollection<AccessLevel> AccessLevelCreateByNavigation { get; set; }
        public virtual ICollection<AccessLevel> AccessLevelModifyByNavigation { get; set; }
        public virtual ICollection<AppAction> AppActionCreateByNavigation { get; set; }
        public virtual ICollection<AppAction> AppActionModifyByNavigation { get; set; }
        public virtual ICollection<AppConfig> AppConfigCreateByNavigation { get; set; }
        public virtual ICollection<AppConfig> AppConfigModifyByNavigation { get; set; }
        public virtual ICollection<AppDocument> AppDocumentCreateByNavigation { get; set; }
        public virtual ICollection<AppDocument> AppDocumentModifyByNavigation { get; set; }
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
        public virtual ICollection<CoursesPlanning> CoursesPlanningCreateByNavigation { get; set; }
        public virtual ICollection<CoursesPlanning> CoursesPlanningModifyByNavigation { get; set; }
        public virtual ICollection<CoursesPlanningStudent> CoursesPlanningStudentCreateByNavigation { get; set; }
        public virtual ICollection<CoursesPlanningStudent> CoursesPlanningStudentModifyByNavigation { get; set; }
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
        public virtual ICollection<EducationalCenter> EducationalCenterModifyByNavigation { get; set; }
        public virtual ICollection<Hr> HrCreateByNavigation { get; set; }
        public virtual ICollection<Hr> HrModifyByNavigation { get; set; }
        public virtual ICollection<Menu> MenuCreateByNavigation { get; set; }
        public virtual ICollection<Menu> MenuModifyByNavigation { get; set; }
        public virtual ICollection<Organization> OrganizationCreateByNavigation { get; set; }
        public virtual ICollection<Organization> OrganizationModifyByNavigation { get; set; }
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
        public virtual ICollection<Representation> RepresentationCreateByNavigation { get; set; }
        public virtual ICollection<Representation> RepresentationModifyByNavigation { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPersonCreateByNavigation { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPersonModifyByNavigation { get; set; }
        public virtual ICollection<Resource> ResourceCreateByNavigation { get; set; }
        public virtual ICollection<Resource> ResourceModifyByNavigation { get; set; }
        public virtual ICollection<Role> RoleCreateByNavigation { get; set; }
        public virtual ICollection<RoleDashboard> RoleDashboardCreateByNavigation { get; set; }
        public virtual ICollection<RoleDashboard> RoleDashboardModifyByNavigation { get; set; }
        public virtual ICollection<Role> RoleModifyByNavigation { get; set; }
        public virtual ICollection<RoleReport> RoleReportCreateByNavigation { get; set; }
        public virtual ICollection<RoleReport> RoleReportModifyByNavigation { get; set; }
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
