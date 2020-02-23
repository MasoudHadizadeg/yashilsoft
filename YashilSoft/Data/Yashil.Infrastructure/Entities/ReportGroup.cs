﻿using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class ReportGroup
    {
        public ReportGroup()
        {
            ReportGroupReport = new HashSet<ReportGroupReport>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual ICollection<ReportGroupReport> ReportGroupReport { get; set; }
    }
}