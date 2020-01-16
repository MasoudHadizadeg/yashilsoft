﻿using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yashil.Core.Entities
{
[Table("DashboardStore", Schema = "dash")]
    public partial class DashboardStore : IBaseEntity<int>
    {
        public DashboardStore()
        {
            DashboardConnectionString = new HashSet<DashboardConnectionString>();
            DashboardGroupDashboard = new HashSet<DashboardGroupDashboard>();
            RoleDashboard = new HashSet<RoleDashboard>();
            UserDashboard = new HashSet<UserDashboard>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(150)]
        public string Code { get; set; }
        [Required]
        [StringLength(300)]
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] DashboardFile { get; set; }
        [StringLength(50)]
        public string CssClass { get; set; }
        public byte[] Picture { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        public bool? Animation { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModificationDate { get; set; }
        public int? ApplicationId { get; set; }
        public int AccessLevelId { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("AccessLevelId")]
        [InverseProperty("DashboardStore")]
        public virtual AccessLevel AccessLevel { get; set; }
        [ForeignKey("ApplicationId")]
        [InverseProperty("DashboardStore")]
        public virtual Application Application { get; set; }
        [ForeignKey("CreateBy")]
        [InverseProperty("DashboardStoreCreateByNavigation")]
        public virtual User CreateByNavigation { get; set; }
        [ForeignKey("ModifyBy")]
        [InverseProperty("DashboardStoreModifyByNavigation")]
        public virtual User ModifyByNavigation { get; set; }
        [InverseProperty("Dashboard")]
        public virtual ICollection<DashboardConnectionString> DashboardConnectionString { get; set; }
        [InverseProperty("DashboardStore")]
        public virtual ICollection<DashboardGroupDashboard> DashboardGroupDashboard { get; set; }
        [InverseProperty("Dashboard")]
        public virtual ICollection<RoleDashboard> RoleDashboard { get; set; }
        [InverseProperty("Dashboard")]
        public virtual ICollection<UserDashboard> UserDashboard { get; set; }
    }
    }