using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class UserDashboard
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DashboardId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? ApplicationId { get; set; }
        public bool Deleted { get; set; }

        public virtual User CreateByNavigation { get; set; }
        public virtual DashboardStore Dashboard { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
