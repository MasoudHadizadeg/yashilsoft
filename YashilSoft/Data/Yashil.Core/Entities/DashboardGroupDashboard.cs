using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class DashboardGroupDashboard : IBaseEntity<int>
    {
        public int Id { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int DashboardStoreId { get; set; }
        public int DashboardGroupId { get; set; }
        public bool Deleted { get; set; }

        public virtual User CreateByNavigation { get; set; }
        public virtual DashboardGroup DashboardGroup { get; set; }
        public virtual DashboardStore DashboardStore { get; set; }
        public virtual User ModifyByNavigation { get; set; }
    }
    }
