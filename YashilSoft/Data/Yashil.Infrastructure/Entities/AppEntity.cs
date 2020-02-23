﻿using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class AppEntity
    {
        public AppEntity()
        {
            DocType = new HashSet<DocType>();
            DocumentCategory = new HashSet<DocumentCategory>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int ObjectId { get; set; }
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

        public virtual DocFormat CreateByNavigation { get; set; }
        public virtual DocFormat ModifyByNavigation { get; set; }
        public virtual ICollection<DocType> DocType { get; set; }
        public virtual ICollection<DocumentCategory> DocumentCategory { get; set; }
    }
}