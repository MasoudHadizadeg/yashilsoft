using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class AppEntity :IBaseEntity<int> 
    {
        public AppEntity()
        {
            AppEntityAttributeMapping = new HashSet<AppEntityAttributeMapping>();
            DocumentCategory = new HashSet<DocumentCategory>();
            Service = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public bool GenerateTabForDescColumn { get; set; }
        public bool HasAttachmenet { get; set; }
        public int? SystemId { get; set; }
        public string TitlePropertyName { get; set; }
        public bool? IsLarge { get; set; }
        public bool IsVirtualEntity { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public string Props { get; set; }
        public string PersianTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string ApplicationBased { get; set; }

        public virtual ICollection<AppEntityAttributeMapping> AppEntityAttributeMapping { get; set; }
        public virtual ICollection<DocumentCategory> DocumentCategory { get; set; }
        public virtual ICollection<Service> Service { get; set; }
    }
    }
