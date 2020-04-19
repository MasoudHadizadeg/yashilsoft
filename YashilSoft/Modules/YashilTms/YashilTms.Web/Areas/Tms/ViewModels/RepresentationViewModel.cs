using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilTms.Web.Areas.Tms.ViewModels
{
    public class RepresentationListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        public string EconomicCode { get; set; }
        public string Code { get; set; }
        public string FounderFullName { get; set; }
        public string Title { get; set; }

        public string EducationalCenterTitle { get; set; }

        public string CityTitle { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string FaxNumber { get; set; }

        public string LicenseNumber { get; set; }

        public string LicenseTypeTitle { get; set; }

        public string OwnershipTypeTitle { get; set; }

        public int? Area { get; set; }

        public string PostalCode { get; set; }

        public string Address { get; set; }

        public string AccessLevelTitle { get; set; }
    }

    public class RepresentationEditModel : IBaseViewModel
    {
        public RepresentationEditModel()
        {
            CourseCategories = new List<int>();
        }

        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int LicenseExpireTime { get; set; }
        public bool Confirmed { get; set; }
        public int FounderId { get; set; }
        public int Id { get; set; }
        [StringLength(300)] public string Code { get; set; }
        [StringLength(20)] public string EconomicCode { get; set; }
        [StringLength(600)] [Required] public string Title { get; set; }
        [Range(0, int.MaxValue)] [Required] public int EducationalCenterId { get; set; }
        [Range(0, int.MaxValue)] [Required] public int CityId { get; set; }
        [StringLength(600)] public string Email { get; set; }
        [StringLength(20)] public string Telephone { get; set; }
        [StringLength(20)] public string FaxNumber { get; set; }
        [StringLength(400)] public string LicenseNumber { get; set; }
        public int? LicenseType { get; set; }
        public int? OwnershipType { get; set; }
        public int? Area { get; set; }
        [StringLength(10)] public string PostalCode { get; set; }
        [StringLength(600)] public string Address { get; set; }
        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }
        public List<int> CourseCategories { get; set; }
    }

    public class RepresentationSimpleViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Title { get; set; }
    }
}