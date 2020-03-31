using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilTms.Web.Areas.Tms.ViewModels
{
    public class CourseListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string CourseCategoryTitle { get; set; }

        public string EducationalCenterTitle { get; set; }

        public string SkillTypeTitle { get; set; }

        public string CertificateTypeTitle { get; set; }

        public string EvaluationMethodTitle { get; set; }

        public int Duration { get; set; }

        public string AccessLevelTitle { get; set; }
    }


    public class CourseEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        [StringLength(300)] public string Code { get; set; }
        [StringLength(600)] [Required] public string Title { get; set; }
        [Range(0, int.MaxValue)] [Required] public int CourseCategoryId { get; set; }
        [Range(0, int.MaxValue)] [Required] public int EducationalCenterId { get; set; }
        public int? SkillType { get; set; }
        public int? CertificateType { get; set; }
        public int? EvaluationMethod { get; set; }
        [Range(0, int.MaxValue)] [Required] public int Duration { get; set; }
        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }

    }


    public class CourseSimpleViewModel : IBaseViewModel
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