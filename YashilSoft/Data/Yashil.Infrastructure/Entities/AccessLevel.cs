﻿using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class AccessLevel
    {
        public AccessLevel()
        {
            DashboardStore = new HashSet<DashboardStore>();
            ReportStore = new HashSet<ReportStore>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int LevelValue { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }
        public int ApplicationId { get; set; }

        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<DashboardStore> DashboardStore { get; set; }
        public virtual ICollection<ReportStore> ReportStore { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}