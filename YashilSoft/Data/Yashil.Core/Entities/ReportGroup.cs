using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class ReportGroup : IBaseEntity<int>
    {
        public ReportGroup()
        {
            ReportGroupReport = new HashSet<ReportGroupReport>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? ApplicationId { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<ReportGroupReport> ReportGroupReport { get; set; }
    }
    }
