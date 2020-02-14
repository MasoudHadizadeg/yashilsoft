using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class Role :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public Role()
        {
            RoleDashboard = new HashSet<RoleDashboard>();
            RoleReport = new HashSet<RoleReport>();
            RoleResourceAction = new HashSet<RoleResourceAction>();
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<RoleDashboard> RoleDashboard { get; set; }
        public virtual ICollection<RoleReport> RoleReport { get; set; }
        public virtual ICollection<RoleResourceAction> RoleResourceAction { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
    }
