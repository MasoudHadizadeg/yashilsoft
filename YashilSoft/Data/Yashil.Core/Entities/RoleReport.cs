﻿using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class RoleReport :IBaseEntity<int> 
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ReportId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }

        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ReportStore Report { get; set; }
        public virtual Role Role { get; set; }
    }
    }
