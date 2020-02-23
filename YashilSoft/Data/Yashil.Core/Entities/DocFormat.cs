using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class DocFormat :IBaseEntity<int> 
    {
        public DocFormat()
        {
            AppEntityCreateByNavigation = new HashSet<AppEntity>();
            AppEntityModifyByNavigation = new HashSet<AppEntity>();
            DocType = new HashSet<DocType>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Extensions { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }

        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<AppEntity> AppEntityCreateByNavigation { get; set; }
        public virtual ICollection<AppEntity> AppEntityModifyByNavigation { get; set; }
        public virtual ICollection<DocType> DocType { get; set; }
    }
    }
