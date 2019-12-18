using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;
 

namespace Yashil.Core.Entities
{
    public partial class Menu : IBaseEntity<int>
    {
        public Menu()
        {
            InverseParent = new HashSet<Menu>();
        }

        public int Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Class { get; set; }
        public string Badge { get; set; }
        public string BadgeClass { get; set; }
        public bool? IsExternalLink { get; set; }
        public int? ParentId { get; set; }
        public int? ResourceId { get; set; }
        public bool IsVirtual { get; set; }
        public int? OrderNo { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? ApplicationId { get; set; }
        public bool Deleted { get; set; }

        public virtual Application Application { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual Menu Parent { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual ICollection<Menu> InverseParent { get; set; }
    }
    }
