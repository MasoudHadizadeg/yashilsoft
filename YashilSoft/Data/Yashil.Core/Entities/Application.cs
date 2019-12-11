using System;
using System.Collections.Generic;
using Yashil.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class Application : IBaseEntity<int>
    {
        public Application()
        {
            AppAction = new HashSet<AppAction>();
            AppConfig = new HashSet<AppConfig>();
            DashboardStore = new HashSet<DashboardStore>();
            Menu = new HashSet<Menu>();
            Organization = new HashSet<Organization>();
            Resource = new HashSet<Resource>();
            Role = new HashSet<Role>();
            User = new HashSet<User>();
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

        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<AppAction> AppAction { get; set; }
        public virtual ICollection<AppConfig> AppConfig { get; set; }
        public virtual ICollection<DashboardStore> DashboardStore { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<Organization> Organization { get; set; }
        public virtual ICollection<Resource> Resource { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
    }
