﻿using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class YashilDataProvider
    {
        public YashilDataProvider()
        {
            YashilConnectionString = new HashSet<YashilConnectionString>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string BaseType { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }

        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<YashilConnectionString> YashilConnectionString { get; set; }
    }
}