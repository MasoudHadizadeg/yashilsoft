﻿using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Core.Entities
{
    public partial class Representation :IBaseEntity<int> ,IApplicationBasedEntity
    {
        public Representation()
        {
            AdditionalUserProp = new HashSet<AdditionalUserProp>();
            CoursePlanning = new HashSet<CoursePlanning>();
            RepresentationCourseCategory = new HashSet<RepresentationCourseCategory>();
            RepresentationEstablishedLicenseType = new HashSet<RepresentationEstablishedLicenseType>();
            RepresentationPerson = new HashSet<RepresentationPerson>();
            RepresentationTeacher = new HashSet<RepresentationTeacher>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public bool Confirmed { get; set; }
        public int EducationalCenterId { get; set; }
        public int FounderId { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string FaxNumber { get; set; }
        public string LicenseNumber { get; set; }
        public int LicenseExpireTime { get; set; }
        public int? LicenseType { get; set; }
        public int? OwnershipType { get; set; }
        public int? Area { get; set; }
        public string PostalCode { get; set; }
        public string About { get; set; }
        public string Address { get; set; }
        public string Goal { get; set; }
        public string Description { get; set; }
        public string Ability { get; set; }
        public string EconomicCode { get; set; }
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
        public virtual Person Founder { get; set; }
        public virtual CommonBaseData LicenseTypeNavigation { get; set; }
        public virtual User ModifyByNavigation { get; set; }
        public virtual CommonBaseData OwnershipTypeNavigation { get; set; }
        public virtual ICollection<AdditionalUserProp> AdditionalUserProp { get; set; }
        public virtual ICollection<CoursePlanning> CoursePlanning { get; set; }
        public virtual ICollection<RepresentationCourseCategory> RepresentationCourseCategory { get; set; }
        public virtual ICollection<RepresentationEstablishedLicenseType> RepresentationEstablishedLicenseType { get; set; }
        public virtual ICollection<RepresentationPerson> RepresentationPerson { get; set; }
        public virtual ICollection<RepresentationTeacher> RepresentationTeacher { get; set; }
    }
    }
