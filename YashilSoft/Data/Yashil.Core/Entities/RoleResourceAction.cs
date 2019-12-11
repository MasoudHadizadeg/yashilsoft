using System;
using System.Collections.Generic;
using Yashil.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class RoleResourceAction : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int ResourceActionId { get; set; }
        public int RoleId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }

        public virtual ResourceAppAction ResourceAction { get; set; }
        public virtual Role Role { get; set; }
    }
    }
