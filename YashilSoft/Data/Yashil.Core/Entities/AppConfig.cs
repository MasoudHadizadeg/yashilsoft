﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yashil.Core.Entities
{
[Table("AppConfig", Schema = "um")]
    public partial class AppConfig : IBaseEntity<int>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string KeyTitle { get; set; }
        [Required]
        [StringLength(150)]
        public string Value { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("ApplicationId")]
        [InverseProperty("AppConfig")]
        public virtual Application Application { get; set; }
        [ForeignKey("CreateBy")]
        [InverseProperty("AppConfigCreateByNavigation")]
        public virtual User CreateByNavigation { get; set; }
        [ForeignKey("ModifyBy")]
        [InverseProperty("AppConfigModifyByNavigation")]
        public virtual User ModifyByNavigation { get; set; }
    }
    }