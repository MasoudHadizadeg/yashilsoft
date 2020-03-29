using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class Course
    {
        public Course()
        {
            CoursePlanning = new HashSet<CoursePlanning>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int CourseCategoryId { get; set; }
        public int EducationalCenterId { get; set; }
        public string Description { get; set; }
        public string Topic { get; set; }
        public string Prerequisite { get; set; }
        public string Target { get; set; }
        public string Requirements { get; set; }
        public string Skill { get; set; }
        public int? SkillType { get; set; }
        public int? CertificateType { get; set; }
        public int? EvaluationMethod { get; set; }
        public int Duration { get; set; }
        public string Audience { get; set; }
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
        public virtual CommonBaseData CertificateTypeNavigation { get; set; }
        public virtual CourseCategory CourseCategory { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual EducationalCenter EducationalCenter { get; set; }
        public virtual CommonBaseData EvaluationMethodNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual CommonBaseData SkillTypeNavigation { get; set; }
        public virtual ICollection<CoursePlanning> CoursePlanning { get; set; }
    }
}
