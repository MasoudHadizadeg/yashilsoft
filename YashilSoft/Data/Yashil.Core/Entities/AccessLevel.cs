using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class AccessLevel :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public AccessLevel()
        {
            AppEntityAttribute = new HashSet<AppEntityAttribute>();
            AppEntityAttributeMapping = new HashSet<AppEntityAttributeMapping>();
            AppEntityAttributeValue = new HashSet<AppEntityAttributeValue>();
            CommonBaseData = new HashSet<CommonBaseData>();
            CommonBaseType = new HashSet<CommonBaseType>();
            Course = new HashSet<Course>();
            CourseCategory = new HashSet<CourseCategory>();
            CoursesPlanning = new HashSet<CoursesPlanning>();
            CoursesPlanningStudent = new HashSet<CoursesPlanningStudent>();
            DashboardStore = new HashSet<DashboardStore>();
            EducationalCenter = new HashSet<EducationalCenter>();
            Person = new HashSet<Person>();
            Post = new HashSet<Post>();
            ReportStore = new HashSet<ReportStore>();
            Representation = new HashSet<Representation>();
            RepresentationPerson = new HashSet<RepresentationPerson>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int LevelValue { get; set; }
        public string Description { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }
        public int ApplicationId { get; set; }

        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<AppEntityAttribute> AppEntityAttribute { get; set; }
        public virtual ICollection<AppEntityAttributeMapping> AppEntityAttributeMapping { get; set; }
        public virtual ICollection<AppEntityAttributeValue> AppEntityAttributeValue { get; set; }
        public virtual ICollection<CommonBaseData> CommonBaseData { get; set; }
        public virtual ICollection<CommonBaseType> CommonBaseType { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<CourseCategory> CourseCategory { get; set; }
        public virtual ICollection<CoursesPlanning> CoursesPlanning { get; set; }
        public virtual ICollection<CoursesPlanningStudent> CoursesPlanningStudent { get; set; }
        public virtual ICollection<DashboardStore> DashboardStore { get; set; }
        public virtual ICollection<EducationalCenter> EducationalCenter { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<ReportStore> ReportStore { get; set; }
        public virtual ICollection<Representation> Representation { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPerson { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
    }
