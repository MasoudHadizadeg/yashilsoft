using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class Organization
    {
        public Organization()
        {
            AccessLevel = new HashSet<AccessLevel>();
            AdditionalUserProp = new HashSet<AdditionalUserProp>();
            AppConfig = new HashSet<AppConfig>();
            AppDocument = new HashSet<AppDocument>();
            AppEntityAttribute = new HashSet<AppEntityAttribute>();
            AppEntityAttributeMapping = new HashSet<AppEntityAttributeMapping>();
            AppEntityAttributeValue = new HashSet<AppEntityAttributeValue>();
            CommonBaseData = new HashSet<CommonBaseData>();
            CommonBaseType = new HashSet<CommonBaseType>();
            Course = new HashSet<Course>();
            CourseCategory = new HashSet<CourseCategory>();
            CoursesPlanning = new HashSet<CoursesPlanning>();
            CoursesPlanningStudent = new HashSet<CoursesPlanningStudent>();
            DashboardGroup = new HashSet<DashboardGroup>();
            DashboardStore = new HashSet<DashboardStore>();
            DocType = new HashSet<DocType>();
            DocumentCategory = new HashSet<DocumentCategory>();
            EducationalCenter = new HashSet<EducationalCenter>();
            InverseParent = new HashSet<Organization>();
            Person = new HashSet<Person>();
            Post = new HashSet<Post>();
            ReportGroup = new HashSet<ReportGroup>();
            ReportStore = new HashSet<ReportStore>();
            Representation = new HashSet<Representation>();
            RepresentationPerson = new HashSet<RepresentationPerson>();
            Role = new HashSet<Role>();
            UserCreatorOrganization = new HashSet<User>();
            UserOrganization = new HashSet<User>();
            YashilConnectionString = new HashSet<YashilConnectionString>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public int? ParentId { get; set; }
        public long? UniqueId { get; set; }
        public string CodePath { get; set; }
        public int? Type { get; set; }
        public int? ProvinceId { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int ApplicationId { get; set; }
        public bool Deleted { get; set; }
        public int CreatorOrganizationId { get; set; }

        public virtual Application Application { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual Organization Parent { get; set; }
        public virtual ICollection<AccessLevel> AccessLevel { get; set; }
        public virtual ICollection<AdditionalUserProp> AdditionalUserProp { get; set; }
        public virtual ICollection<AppConfig> AppConfig { get; set; }
        public virtual ICollection<AppDocument> AppDocument { get; set; }
        public virtual ICollection<AppEntityAttribute> AppEntityAttribute { get; set; }
        public virtual ICollection<AppEntityAttributeMapping> AppEntityAttributeMapping { get; set; }
        public virtual ICollection<AppEntityAttributeValue> AppEntityAttributeValue { get; set; }
        public virtual ICollection<CommonBaseData> CommonBaseData { get; set; }
        public virtual ICollection<CommonBaseType> CommonBaseType { get; set; }
        public virtual ICollection<Course> Course { get; set; }
        public virtual ICollection<CourseCategory> CourseCategory { get; set; }
        public virtual ICollection<CoursesPlanning> CoursesPlanning { get; set; }
        public virtual ICollection<CoursesPlanningStudent> CoursesPlanningStudent { get; set; }
        public virtual ICollection<DashboardGroup> DashboardGroup { get; set; }
        public virtual ICollection<DashboardStore> DashboardStore { get; set; }
        public virtual ICollection<DocType> DocType { get; set; }
        public virtual ICollection<DocumentCategory> DocumentCategory { get; set; }
        public virtual ICollection<EducationalCenter> EducationalCenter { get; set; }
        public virtual ICollection<Organization> InverseParent { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<ReportGroup> ReportGroup { get; set; }
        public virtual ICollection<ReportStore> ReportStore { get; set; }
        public virtual ICollection<Representation> Representation { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPerson { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<User> UserCreatorOrganization { get; set; }
        public virtual ICollection<User> UserOrganization { get; set; }
        public virtual ICollection<YashilConnectionString> YashilConnectionString { get; set; }
    }
}
