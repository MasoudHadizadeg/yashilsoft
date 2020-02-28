using System;
using System.Collections.Generic;

namespace Yashil.Infrastructure.Entities
{
    public partial class Representation
    {
        public Representation()
        {
            CoursesPlanning = new HashSet<CoursesPlanning>();
            RepresentationPerson = new HashSet<RepresentationPerson>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int EducationalCenterId { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string FaxNumber { get; set; }
        public string LicenseNumber { get; set; }
        public int? LicenseType { get; set; }
        public int? OwnershipType { get; set; }
        public int? EstablishedLicenseType { get; set; }
        public int? Area { get; set; }
        public int? OwnershipTypeId { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
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
        public virtual City City { get; set; }
        public virtual User CreateByNavigation { get; set; }
        public virtual Organization CreatorOrganization { get; set; }
        public virtual EducationalCenter EducationalCenter { get; set; }
        public virtual CommonBaseData LicenseTypeNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual CommonBaseData OwnershipTypeNavigation { get; set; }
        public virtual ICollection<CoursesPlanning> CoursesPlanning { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPerson { get; set; }
    }
}
