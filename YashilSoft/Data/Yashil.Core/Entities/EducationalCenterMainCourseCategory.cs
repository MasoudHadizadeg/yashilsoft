﻿using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class EducationalCenterMainCourseCategory :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public EducationalCenterMainCourseCategory()
        {
            CourseCategory = new HashSet<CourseCategory>();
        }

        public int Id { get; set; }
        public int EducationalCenterId { get; set; }
        public int MainCourseCategoryId { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual EducationalCenter EducationalCenter { get; set; }
        public virtual MainCourseCategory MainCourseCategory { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<CourseCategory> CourseCategory { get; set; }
    }
    }
