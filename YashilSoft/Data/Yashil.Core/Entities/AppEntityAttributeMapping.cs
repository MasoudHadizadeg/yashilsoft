using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class AppEntityAttributeMapping :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public AppEntityAttributeMapping()
        {
            AppEntityAttributeValue = new HashSet<AppEntityAttributeValue>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int AppEntityId { get; set; }
        public int AppEntityAttributeId { get; set; }
        public bool IsRequired { get; set; }
        public int AttributeControlType { get; set; }
        public int? DisplayOrder { get; set; }
        public int? ValidationMinLength { get; set; }
        public int? ValidationMaxLength { get; set; }
        public string DefaultValue { get; set; }
        public string AllowedValues { get; set; }
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
        public virtual AppEntity AppEntity { get; set; }
        public virtual AppEntityAttribute AppEntityAttribute { get; set; }
        public virtual Application Application { get; set; }
        public virtual CommonBaseData AttributeControlTypeNavigation { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<AppEntityAttributeValue> AppEntityAttributeValue { get; set; }
    }
    }
