using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class ResourceAppAction : IBaseEntity<int>
    {
        public ResourceAppAction()
        {
            RoleResourceAction = new HashSet<RoleResourceAction>();
        }

        public int Id { get; set; }
        public int AppActionId { get; set; }
        public int ResourceId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }

        public virtual AppAction AppAction { get; set; }
        public virtual Resource Resource { get; set; }
        public virtual ICollection<RoleResourceAction> RoleResourceAction { get; set; }
    }
    }
