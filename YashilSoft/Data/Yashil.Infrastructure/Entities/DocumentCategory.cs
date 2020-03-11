using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class DocumentCategory
    {
        public DocumentCategory()
        {
            AppDocument = new HashSet<AppDocument>();
            InverseParent = new HashSet<DocumentCategory>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public int AppEntityId { get; set; }
        public long ObjectId { get; set; }
        public int? DisplayOrder { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
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
        public virtual User ModifyByNavigation { get; set; }
        public virtual DocumentCategory Parent { get; set; }
        public virtual ICollection<AppDocument> AppDocument { get; set; }
        public virtual ICollection<DocumentCategory> InverseParent { get; set; }
    }
}
