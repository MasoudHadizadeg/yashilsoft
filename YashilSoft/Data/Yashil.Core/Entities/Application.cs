﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yashil.Core.Entities
{
[Table("Application", Schema = "um")]
    public partial class Application : IBaseEntity<int>
    {
        public Application()
        {
            AppAction = new HashSet<AppAction>();
            AppConfig = new HashSet<AppConfig>();
            DashboardStore = new HashSet<DashboardStore>();
            InverseParent = new HashSet<Application>();
            Organization = new HashSet<Organization>();
            ReportGroup = new HashSet<ReportGroup>();
            ReportStore = new HashSet<ReportStore>();
            Role = new HashSet<Role>();
            User = new HashSet<User>();
            YashilConnectionString = new HashSet<YashilConnectionString>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        [StringLength(10)]
        public string Url { get; set; }
        public byte[] SecretKey { get; set; }
        [Column(TypeName = "xml")]
        public string AdditionalInfo { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public int? ParentId { get; set; }

        [ForeignKey("CreateBy")]
        [InverseProperty("ApplicationCreateByNavigation")]
        public virtual User CreateByNavigation { get; set; }
        [ForeignKey("ModifyBy")]
        [InverseProperty("ApplicationModifyByNavigation")]
        public virtual User ModifyByNavigation { get; set; }
        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public virtual Application Parent { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<AppAction> AppAction { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<AppConfig> AppConfig { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<DashboardStore> DashboardStore { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<Application> InverseParent { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<Organization> Organization { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<ReportGroup> ReportGroup { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<ReportStore> ReportStore { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<Role> Role { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<User> User { get; set; }
        [InverseProperty("Application")]
        public virtual ICollection<YashilConnectionString> YashilConnectionString { get; set; }
    }
    }