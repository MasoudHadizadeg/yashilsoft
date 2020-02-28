using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class Application :IBaseEntity<int> 
    {
        public Application()
        {
            AppAction = new HashSet<AppAction>();
            AppConfig = new HashSet<AppConfig>();
            AppDocument = new HashSet<AppDocument>();
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
            Hr = new HashSet<Hr>();
            InverseParent = new HashSet<Application>();
            Menu = new HashSet<Menu>();
            Organization = new HashSet<Organization>();
            Person = new HashSet<Person>();
            Post = new HashSet<Post>();
            ReportGroup = new HashSet<ReportGroup>();
            ReportStore = new HashSet<ReportStore>();
            Representation = new HashSet<Representation>();
            RepresentationPerson = new HashSet<RepresentationPerson>();
            Role = new HashSet<Role>();
            User = new HashSet<User>();
            YashilConnectionString = new HashSet<YashilConnectionString>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public byte[] SecretKey { get; set; }
        public string AdditionalInfo { get; set; }
        public int CreateBy { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public bool Deleted { get; set; }
        public int? ParentId { get; set; }

        public virtual User CreateByNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual Application Parent { get; set; }
        public virtual ICollection<AppAction> AppAction { get; set; }
        public virtual ICollection<AppConfig> AppConfig { get; set; }
        public virtual ICollection<AppDocument> AppDocument { get; set; }
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
        public virtual ICollection<Hr> Hr { get; set; }
        public virtual ICollection<Application> InverseParent { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<Organization> Organization { get; set; }
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<ReportGroup> ReportGroup { get; set; }
        public virtual ICollection<ReportStore> ReportStore { get; set; }
        public virtual ICollection<Representation> Representation { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPerson { get; set; }
        public virtual ICollection<Role> Role { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<YashilConnectionString> YashilConnectionString { get; set; }
    }
    }
