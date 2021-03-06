﻿using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class AppDocument :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public int Id { get; set; }
        public int DocTypeId { get; set; }
        public string Title { get; set; }
        public string OrginalName { get; set; }
        public long ObjectId { get; set; }
        public byte[] DocumentFile { get; set; }
        public string ShortDescription { get; set; }
        public int? DisplayOrder { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual DocType DocType { get; set; }
        public virtual User ModifyByNavigation { get; set; }
    }
    }
