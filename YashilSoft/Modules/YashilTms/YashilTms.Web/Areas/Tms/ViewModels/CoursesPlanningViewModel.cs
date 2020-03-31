using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilTms.Web.Areas.Tms.ViewModels
{
    public class CoursePlanningListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string RepresentationTitle { get; set; }

        public bool Organizational { get; set; }

        public string CourseStatusTitle { get; set; }

        public string RepresentationPersonTitle { get; set; }

        public int? Price { get; set; }

        public string CourseTitle { get; set; }

        public string AgeCategoryTitle { get; set; }

        public string ImplementationTypeTitle { get; set; }

        public string CourseTypeTitle { get; set; }

        public string RunTypeTitle { get; set; }

        public int StartDate { get; set; }

        public string CustomGenderTitle { get; set; }

        public int MaxCapacity { get; set; }

        public string AccessLevelTitle { get; set; }
    }


    public class CoursePlanningEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        [StringLength(300)] public string Code { get; set; }
        [Range(0, int.MaxValue)] [Required] public int RepresentationId { get; set; }
        public bool Organizational { get; set; }
        [Range(0, int.MaxValue)] [Required] public int CourseStatus { get; set; }
        public int? RepresentationPersonId { get; set; }
        public int? Price { get; set; }
        [Range(0, int.MaxValue)] [Required] public int CourseId { get; set; }
        public int? AgeCategory { get; set; }
        [Range(0, int.MaxValue)] [Required] public int ImplementationType { get; set; }
        [Range(0, int.MaxValue)] [Required] public int CourseType { get; set; }
        [Range(0, int.MaxValue)] [Required] public int RunType { get; set; }
        [Range(0, int.MaxValue)] [Required] public int StartDate { get; set; }
        [Range(0, int.MaxValue)] [Required] public int CustomGender { get; set; }
        [Range(0, int.MaxValue)] [Required] public int MaxCapacity { get; set; }
        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }
        [Required] public int CourseCategoryId { get; set; }
        public string CourseTitle { get; set; }
    }


    public class CoursePlanningSimpleViewModel : IBaseViewModel
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