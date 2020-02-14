using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class DashboardStore :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public DashboardStore()
        {
            DashboardConnectionString = new HashSet<DashboardConnectionString>();
            DashboardGroupDashboard = new HashSet<DashboardGroupDashboard>();
            RoleDashboard = new HashSet<RoleDashboard>();
            UserDashboard = new HashSet<UserDashboard>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] DashboardFile { get; set; }
        public string CssClass { get; set; }
        public byte[] Picture { get; set; }
        public string Color { get; set; }
        public bool? Animation { get; set; }
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
        public virtual ICollection<DashboardConnectionString> DashboardConnectionString { get; set; }
        public virtual ICollection<DashboardGroupDashboard> DashboardGroupDashboard { get; set; }
        public virtual ICollection<RoleDashboard> RoleDashboard { get; set; }
        public virtual ICollection<UserDashboard> UserDashboard { get; set; }
    }
    }
