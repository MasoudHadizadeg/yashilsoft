using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class DocType :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public DocType()
        {
            AppDocument = new HashSet<AppDocument>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AppEntityId { get; set; }
        public int? DisplayOrder { get; set; }
        public bool SaveToDisk { get; set; }
        public int MaxSize { get; set; }
        public int MaxCount { get; set; }
        public int DocFormatId { get; set; }
        public bool IsImage { get; set; }
        public bool CropImage { get; set; }
        public double AspectRatio { get; set; }
        public bool? IsTitleRequired { get; set; }
        public bool? IsCategorized { get; set; }
        public int CreatorOrganizationId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public bool Deleted { get; set; }

        public virtual AppEntity AppEntity { get; set; }
        public virtual Application Application { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual DocFormat DocFormat { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<AppDocument> AppDocument { get; set; }
    }
    }
