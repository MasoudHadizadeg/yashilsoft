﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yashil.Core.Entities
{
[Table("DashboardConnectionString", Schema = "dash")]
    public partial class DashboardConnectionString : IBaseEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public int DashboardId { get; set; }
        public int ConnectionStringId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModificationDate { get; set; }
        public int? ApplicationId { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("ConnectionStringId")]
        [InverseProperty("DashboardConnectionString")]
        public virtual YashilConnectionString ConnectionString { get; set; }
        [ForeignKey("CreateBy")]
        [InverseProperty("DashboardConnectionStringCreateByNavigation")]
        public virtual User CreateByNavigation { get; set; }
        [ForeignKey("DashboardId")]
        [InverseProperty("DashboardConnectionString")]
        public virtual DashboardStore Dashboard { get; set; }
        [ForeignKey("ModifyBy")]
        [InverseProperty("DashboardConnectionStringModifyByNavigation")]
        public virtual User ModifyByNavigation { get; set; }
    }
    }