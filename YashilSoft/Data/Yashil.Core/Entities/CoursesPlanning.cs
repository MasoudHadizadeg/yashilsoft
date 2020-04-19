﻿using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class CoursesPlanning :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public CoursesPlanning()
        {
            CoursesPlanningStudent = new HashSet<CoursesPlanningStudent>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public int RepresentationId { get; set; }
        public bool Organizational { get; set; }
        public int CourceStatus { get; set; }
        public int? RepresentationPersonId { get; set; }
        public int? Price { get; set; }
        public int CourseId { get; set; }
        public int? AgeCategory { get; set; }
        public int ImplementationType { get; set; }
        public int CourceType { get; set; }
        public int RunType { get; set; }
        public int StartDate { get; set; }
        public int CustomGender { get; set; }
        public int MaxCapacity { get; set; }
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
        public virtual CommonBaseData AgeCategoryNavigation { get; set; }
        public virtual Application Application { get; set; }
        public virtual CommonBaseData CourceStatusNavigation { get; set; }
        public virtual CommonBaseData CourceTypeNavigation { get; set; }
        public virtual Course Course { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual CommonBaseData CustomGenderNavigation { get; set; }
        public virtual CommonBaseData ImplementationTypeNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual Representation Representation { get; set; }
        public virtual RepresentationPerson RepresentationPerson { get; set; }
        public virtual CommonBaseData RunTypeNavigation { get; set; }
        public virtual ICollection<CoursesPlanningStudent> CoursesPlanningStudent { get; set; }
    }
    }