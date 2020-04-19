using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilTms.Web.Areas.Tms.ViewModels
{
    public class EducationalCenterCourseCategoryListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int? ParentId { get; set; }
        public int Id { get; set; }

        public string EducationalCenterTitle { get; set; }

        public string CourseCategoryTitle { get; set; }

        public string AccessLevelTitle { get; set; }
    }


    public class EducationalCenterCourseCategoryEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        [Range(0, int.MaxValue)] [Required] public int EducationalCenterId { get; set; }
        [Range(0, int.MaxValue)] [Required] public int CourseCategory { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }
    }


    public class EducationalCenterCourseCategorySimpleViewModel : IBaseViewModel
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