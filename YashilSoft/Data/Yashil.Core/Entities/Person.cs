using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class Person :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public Person()
        {
            CoursePlanningStudent = new HashSet<CoursePlanningStudent>();
            PersonBankAccount = new HashSet<PersonBankAccount>();
            Representation = new HashSet<Representation>();
            RepresentationPerson = new HashSet<RepresentationPerson>();
            RepresentationTeacher = new HashSet<RepresentationTeacher>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public int Gender { get; set; }
        public int? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int? EducationGrade { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
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
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual CommonBaseData EducationGradeNavigation { get; set; }
        public virtual CommonBaseData GenderNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual ICollection<CoursePlanningStudent> CoursePlanningStudent { get; set; }
        public virtual ICollection<PersonBankAccount> PersonBankAccount { get; set; }
        public virtual ICollection<Representation> Representation { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPerson { get; set; }
        public virtual ICollection<RepresentationTeacher> RepresentationTeacher { get; set; }
    }
    }
