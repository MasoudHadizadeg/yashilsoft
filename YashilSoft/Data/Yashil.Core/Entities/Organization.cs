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
            AppConfig = new HashSet<AppConfig>();
            AppDocument = new HashSet<AppDocument>();
            DashboardGroup = new HashSet<DashboardGroup>();
            DashboardStore = new HashSet<DashboardStore>();
            DocType = new HashSet<DocType>();
            DocumentCategory = new HashSet<DocumentCategory>();
            InverseParent = new HashSet<Organization>();
            ReportGroup = new HashSet<ReportGroup>();
            ReportStore = new HashSet<ReportStore>();
            Role = new HashSet<Role>();
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
        public virtual ICollection<AppConfig> AppConfig { get; set; }
        public virtual ICollection<AppDocument> AppDocument { get; set; }
        public virtual ICollection<DashboardGroup> DashboardGroup { get; set; }
        public virtual ICollection<DashboardStore> DashboardStore { get; set; }
        public virtual ICollection<DocType> DocType { get; set; }
        public virtual ICollection<DocumentCategory> DocumentCategory { get; set; }
        public virtual ICollection<Organization> InverseParent { get; set; }
        public virtual ICollection<ReportGroup> ReportGroup { get; set; }
        public virtual ICollection<ReportStore> ReportStore { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<User> UserCreatorOrganization { get; set; }
        public virtual ICollection<User> UserOrganization { get; set; }
        public virtual ICollection<YashilConnectionString> YashilConnectionString { get; set; }
    }
    }
