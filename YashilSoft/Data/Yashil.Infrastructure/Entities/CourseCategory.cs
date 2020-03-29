using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class CourseCategory
    {
        public CourseCategory()
        {
            Course = new HashSet<Course>();
            InverseParent = new HashSet<CourseCategory>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public int EducationalCenterMainCourseCategoryId { get; set; }
        public string Description { get; set; }
        public string CodePath { get; set; }
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
        public virtual EducationalCenterMainCourseCategory EducationalCenterMainCourseCategory { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual CourseCategory Parent { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<CourseCategory> InverseParent { get; set; }
    }
}
