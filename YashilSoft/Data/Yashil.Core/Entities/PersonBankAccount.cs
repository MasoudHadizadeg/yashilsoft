using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class PersonBankAccount :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int BankType { get; set; }
        public string CardNumber { get; set; }
        public string AccountNumber { get; set; }
        public string ShebaNumber { get; set; }
        public string BranchName { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public int? AccessLevelId { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }

        public virtual AccessLevel AccessLevel { get; set; }
        public virtual Application Application { get; set; }
        public virtual CommonBaseData BankTypeNavigation { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual Person Person { get; set; }
    }
    }
