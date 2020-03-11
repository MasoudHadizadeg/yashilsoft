﻿using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class AppEntityAttributeValue
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public int AppEntityAttributeMappingId { get; set; }
        public int ObjectId { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public int AccessLevelId { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }

        public virtual AccessLevel AccessLevel { get; set; }
        public virtual AppEntityAttributeMapping AppEntityAttributeMapping { get; set; }
        public virtual Application Application { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
    }
}
