﻿using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class YashilConnectionString :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public YashilConnectionString()
        {
            DashboardConnectionString = new HashSet<DashboardConnectionString>();
            ReportConnectionString = new HashSet<ReportConnectionString>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int DataProviderId { get; set; }
        public string ConnectionString { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public int ApplicationId { get; set; }
        public int AccessLevelId { get; set; }
        public int CreatorOrganizationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual YashilDataProvider DataProvider { get; set; }
        public virtual ICollection<DashboardConnectionString> DashboardConnectionString { get; set; }
        public virtual ICollection<ReportConnectionString> ReportConnectionString { get; set; }
    }
    }
