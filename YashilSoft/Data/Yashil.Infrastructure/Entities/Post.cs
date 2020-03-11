using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class Post
    {
        public Post()
        {
            InverseParent = new HashSet<Post>();
            RepresentationPerson = new HashSet<RepresentationPerson>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
        public bool IsVirtual { get; set; }
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
        public virtual Application Application { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual Post Parent { get; set; }
        public virtual ICollection<Post> InverseParent { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPerson { get; set; }
    }
}
