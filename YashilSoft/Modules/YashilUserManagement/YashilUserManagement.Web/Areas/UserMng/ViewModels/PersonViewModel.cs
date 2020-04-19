using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{
    public class PersonListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public int Gender { get; set; }
        public string GenderTitle { get; set; }

        public int? BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public int? EducationGrade { get; set; }
        public string EducationGradeTitle { get; set; }

        public string Email { get; set; }

        public string NationalCode { get; set; }

        public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
    }


    public class PersonEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        [StringLength(300)] public string Code { get; set; }

        [StringLength(600)] [Required] public string Name { get; set; }

        [StringLength(600)] [Required] public string LastName { get; set; }

        [StringLength(600)] [Required] public string FatherName { get; set; }

        [Range(0, int.MaxValue)] [Required] public int Gender { get; set; }
        public string GenderTitle { get; set; }


        public int? BirthDate { get; set; }

        [StringLength(100)] public string PhoneNumber { get; set; }


        public int? EducationGrade { get; set; }
        public string EducationGradeTitle { get; set; }

        [StringLength(600)] public string Email { get; set; }

        [StringLength(10)]
        [MinLength(10)]
        [MaxLength(10)]
        [Required]
        public string NationalCode { get; set; }


        public string Description { get; set; }

        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
    }


    public class PersonSimpleViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public string NationalCode { get; set; }
    }
}