﻿using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class Resource :IBaseEntity<int> 
    {
        public Resource()
        {
            Menu = new HashSet<Menu>();
            ResourceAppAction = new HashSet<ResourceAppAction>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Type { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }

        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<ResourceAppAction> ResourceAppAction { get; set; }
    }
    }
