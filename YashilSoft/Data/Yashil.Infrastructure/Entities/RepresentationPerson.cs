﻿using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class RepresentationPerson
    {
        public RepresentationPerson()
        {
            CoursesPlanning = new HashSet<CoursesPlanning>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int RepresentationId { get; set; }
        public int PersonId { get; set; }
        public int PostId { get; set; }
        public int? CooperationType { get; set; }
        public int? FromDate { get; set; }
        public int? ToDate { get; set; }
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
        public virtual CommonBaseData CooperationTypeNavigation { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual Person Person { get; set; }
        public virtual Post Post { get; set; }
        public virtual Representation Representation { get; set; }
        public virtual ICollection<CoursesPlanning> CoursesPlanning { get; set; }
    }
}
