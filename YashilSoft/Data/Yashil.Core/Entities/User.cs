using System;
using System.Collections.Generic;
using Yashil.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class User : IBaseEntity<int>
    {
        public User()
        {
            AccessLevelCreateByNavigation = new HashSet<AccessLevel>();
            AccessLevelModifyByNavigation = new HashSet<AccessLevel>();
            AppActionCreateByNavigation = new HashSet<AppAction>();
            AppActionModifyByNavigation = new HashSet<AppAction>();
            AppConfigCreateByNavigation = new HashSet<AppConfig>();
            AppConfigModifyByNavigation = new HashSet<AppConfig>();
            ApplicationCreateByNavigation = new HashSet<Application>();
            ApplicationModifyByNavigation = new HashSet<Application>();
            DashboardConnectionStringCreateByNavigation = new HashSet<DashboardConnectionString>();
            DashboardConnectionStringModifyByNavigation = new HashSet<DashboardConnectionString>();
            DashboardGroupDashboardCreateByNavigation = new HashSet<DashboardGroupDashboard>();
            DashboardGroupDashboardModifyByNavigation = new HashSet<DashboardGroupDashboard>();
            DashboardStoreCreateByNavigation = new HashSet<DashboardStore>();
            DashboardStoreModifyByNavigation = new HashSet<DashboardStore>();
            MenuCreateByNavigation = new HashSet<Menu>();
            MenuModifyByNavigation = new HashSet<Menu>();
            OrganizationCreateByNavigation = new HashSet<Organization>();
            OrganizationModifyByNavigation = new HashSet<Organization>();
            ReportConnectionStringCreateByNavigation = new HashSet<ReportConnectionString>();
            ReportConnectionStringModifyByNavigation = new HashSet<ReportConnectionString>();
            ReportGroupReportCreateByNavigation = new HashSet<ReportGroupReport>();
            ReportGroupReportModifyByNavigation = new HashSet<ReportGroupReport>();
            ReportStoreCreateByNavigation = new HashSet<ReportStore>();
            ReportStoreModifyByNavigation = new HashSet<ReportStore>();
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
            YashilConnectionStringCreateByNavigation = new HashSet<YashilConnectionString>();
            YashilConnectionStringModifyByNavigation = new HashSet<YashilConnectionString>();
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
        public int? MobileNumber { get; set; }
        public int? OrganizationId { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Address { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? ApplicationId { get; set; }
        public int AccessLevelId { get; set; }
        public bool Deleted { get; set; }

        public virtual AccessLevel AccessLevel { get; set; }
        public virtual Application Application { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<AccessLevel> AccessLevelCreateByNavigation { get; set; }
        public virtual ICollection<AccessLevel> AccessLevelModifyByNavigation { get; set; }
        public virtual ICollection<AppAction> AppActionCreateByNavigation { get; set; }
        public virtual ICollection<AppAction> AppActionModifyByNavigation { get; set; }
        public virtual ICollection<AppConfig> AppConfigCreateByNavigation { get; set; }
        public virtual ICollection<AppConfig> AppConfigModifyByNavigation { get; set; }
        public virtual ICollection<Application> ApplicationCreateByNavigation { get; set; }
        public virtual ICollection<Application> ApplicationModifyByNavigation { get; set; }
        public virtual ICollection<DashboardConnectionString> DashboardConnectionStringCreateByNavigation { get; set; }
        public virtual ICollection<DashboardConnectionString> DashboardConnectionStringModifyByNavigation { get; set; }
        public virtual ICollection<DashboardGroupDashboard> DashboardGroupDashboardCreateByNavigation { get; set; }
        public virtual ICollection<DashboardGroupDashboard> DashboardGroupDashboardModifyByNavigation { get; set; }
        public virtual ICollection<DashboardStore> DashboardStoreCreateByNavigation { get; set; }
        public virtual ICollection<DashboardStore> DashboardStoreModifyByNavigation { get; set; }
        public virtual ICollection<Menu> MenuCreateByNavigation { get; set; }
        public virtual ICollection<Menu> MenuModifyByNavigation { get; set; }
        public virtual ICollection<Organization> OrganizationCreateByNavigation { get; set; }
        public virtual ICollection<Organization> OrganizationModifyByNavigation { get; set; }
        public virtual ICollection<ReportConnectionString> ReportConnectionStringCreateByNavigation { get; set; }
        public virtual ICollection<ReportConnectionString> ReportConnectionStringModifyByNavigation { get; set; }
        public virtual ICollection<ReportGroupReport> ReportGroupReportCreateByNavigation { get; set; }
        public virtual ICollection<ReportGroupReport> ReportGroupReportModifyByNavigation { get; set; }
        public virtual ICollection<ReportStore> ReportStoreCreateByNavigation { get; set; }
        public virtual ICollection<ReportStore> ReportStoreModifyByNavigation { get; set; }
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
        public virtual ICollection<YashilConnectionString> YashilConnectionStringCreateByNavigation { get; set; }
        public virtual ICollection<YashilConnectionString> YashilConnectionStringModifyByNavigation { get; set; }
        public virtual ICollection<YashilDataProvider> YashilDataProviderCreateByNavigation { get; set; }
        public virtual ICollection<YashilDataProvider> YashilDataProviderModifyByNavigation { get; set; }
    }
    }
