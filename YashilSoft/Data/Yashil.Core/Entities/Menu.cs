﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yashil.Core.Entities
{
[Table("Menu", Schema = "um")]
    public partial class Menu : IBaseEntity<int>
    {
        public Menu()
        {
            InverseParent = new HashSet<Menu>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(300)]
        public string Path { get; set; }
        [Required]
        [StringLength(300)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Icon { get; set; }
        [StringLength(100)]
        public string Class { get; set; }
        [StringLength(100)]
        public string Badge { get; set; }
        [StringLength(100)]
        public string BadgeClass { get; set; }
        public bool? IsExternalLink { get; set; }
        public int? ParentId { get; set; }
        public int? ResourceId { get; set; }
        public bool IsVirtual { get; set; }
        public int? OrderNo { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }

        [ForeignKey("CreateBy")]
        [InverseProperty("MenuCreateByNavigation")]
        public virtual User CreateByNavigation { get; set; }
        [ForeignKey("ModifyBy")]
        [InverseProperty("MenuModifyByNavigation")]
        public virtual User ModifyByNavigation { get; set; }
        [ForeignKey("ParentId")]
        [InverseProperty("InverseParent")]
        public virtual Menu Parent { get; set; }
        [ForeignKey("ResourceId")]
        [InverseProperty("Menu")]
        public virtual Resource Resource { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<Menu> InverseParent { get; set; }
    }
    }