using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class Keyword :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public Keyword()
        {
            NewsKeyword = new HashSet<NewsKeyword>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int KeywordType { get; set; }
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
        public virtual CommonBaseData KeywordTypeNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<NewsKeyword> NewsKeyword { get; set; }
    }
    }
