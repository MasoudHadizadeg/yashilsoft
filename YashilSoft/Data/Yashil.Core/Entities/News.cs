using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class News :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public News()
        {
            MainNews = new HashSet<MainNews>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int ServiceId { get; set; }
        public int NewsType { get; set; }
        public string ZirTitr { get; set; }
        public string RuTitr { get; set; }
        public string Titr { get; set; }
        public string SuTitr { get; set; }
        public string Led { get; set; }
        public string Body { get; set; }
        public int DisplayOrder { get; set; }
        public int TimeInsert { get; set; }
        public int DateInsert { get; set; }
        public int? EffluenceTime { get; set; }
        public int? EffluenceDate { get; set; }
        public int? ViewCount { get; set; }
        public int? ExpireDate { get; set; }
        public int? ExpireTime { get; set; }
        public int LanguageSid { get; set; }
        public bool IsOtherSiteNews { get; set; }
        public string NewsWebSiteCode { get; set; }
        public DateTime DateInsertMiladi { get; set; }
        public DateTime? ExpireDateMiladi { get; set; }
        public DateTime? EffluenceDateMiladi { get; set; }
        public bool Confirmed { get; set; }
        public string KeywordStr { get; set; }
        public long? EffluenceFullDateTime { get; set; }
        public long? OtherSiteNewsId { get; set; }
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
        public virtual CommonBaseData NewsTypeNavigation { get; set; }
        public virtual Service Service { get; set; }
        public virtual ICollection<MainNews> MainNews { get; set; }
    }
    }
