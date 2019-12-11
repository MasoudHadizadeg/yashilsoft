using System;
using System.Collections.Generic;
using Yashil.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class Organization : IBaseEntity<int>
    {
        public Organization()
        {
            InverseParent = new HashSet<Organization>();
            User = new HashSet<User>();
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
        public int? ApplicationId { get; set; }
        public bool Deleted { get; set; }

        public virtual Application Application { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual Organization Parent { get; set; }
        public virtual ICollection<Organization> InverseParent { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
    }
