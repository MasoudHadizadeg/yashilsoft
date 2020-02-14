using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class ReportStore
    {
        public ReportStore()
        {
            ReportConnectionString = new HashSet<ReportConnectionString>();
            ReportGroupReport = new HashSet<ReportGroupReport>();
            RoleReport = new HashSet<RoleReport>();
            UserReport = new HashSet<UserReport>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] ReportFile { get; set; }
        public string CssClass { get; set; }
        public byte[] Picture { get; set; }
        public string Color { get; set; }
        public bool? Animation { get; set; }
        public string Description { get; set; }
        public string ReportKey { get; set; }
        public string DesignString { get; set; }
        public string ModuleKey { get; set; }
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
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<ReportConnectionString> ReportConnectionString { get; set; }
        public virtual ICollection<ReportGroupReport> ReportGroupReport { get; set; }
        public virtual ICollection<RoleReport> RoleReport { get; set; }
        public virtual ICollection<UserReport> UserReport { get; set; }
    }
}
