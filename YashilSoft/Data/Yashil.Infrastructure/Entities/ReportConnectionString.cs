﻿using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class ReportConnectionString
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int ConnectionStringId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }

        public virtual YashilConnectionString ConnectionString { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ReportStore Report { get; set; }
    }
}
