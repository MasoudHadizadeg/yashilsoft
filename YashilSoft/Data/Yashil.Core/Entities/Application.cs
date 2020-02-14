using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class Application :IBaseEntity<int> 
    {
        public Application()
        {
            AppAction = new HashSet<AppAction>();
            AppConfig = new HashSet<AppConfig>();
            AppDocument = new HashSet<AppDocument>();
            DashboardGroup = new HashSet<DashboardGroup>();
            DashboardStore = new HashSet<DashboardStore>();
            DocType = new HashSet<DocType>();
            DocumentCategory = new HashSet<DocumentCategory>();
            InverseParent = new HashSet<Application>();
            Organization = new HashSet<Organization>();
            ReportGroup = new HashSet<ReportGroup>();
            ReportStore = new HashSet<ReportStore>();
            Role = new HashSet<Role>();
            User = new HashSet<User>();
            YashilConnectionString = new HashSet<YashilConnectionString>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public byte[] SecretKey { get; set; }
        public string AdditionalInfo { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public int? ParentId { get; set; }

        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual Application Parent { get; set; }
        public virtual ICollection<AppAction> AppAction { get; set; }
        public virtual ICollection<AppConfig> AppConfig { get; set; }
        public virtual ICollection<AppDocument> AppDocument { get; set; }
        public virtual ICollection<DashboardGroup> DashboardGroup { get; set; }
        public virtual ICollection<DashboardStore> DashboardStore { get; set; }
        public virtual ICollection<DocType> DocType { get; set; }
        public virtual ICollection<DocumentCategory> DocumentCategory { get; set; }
        public virtual ICollection<Application> InverseParent { get; set; }
        public virtual ICollection<Organization> Organization { get; set; }
        public virtual ICollection<ReportGroup> ReportGroup { get; set; }
        public virtual ICollection<ReportStore> ReportStore { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<YashilConnectionString> YashilConnectionString { get; set; }
    }
    }
