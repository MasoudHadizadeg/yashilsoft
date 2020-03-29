using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilTms.Web.Areas.Tms.ViewModels
{
    public class CourseCategoryListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string ParentTitle { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int DisplayOrder { get; set; }
        public int EducationalCenterMainCourseCategoryId { get; set; }
        public string EducationalCenterMainCourseCategoryTitle { get; set; }
        public string AccessLevelTitle { get; set; }
        public bool IsMainCourseCategory { get; set; }

        public bool AllowEdit => !IsMainCourseCategory;

        public bool AllowDelete => !IsMainCourseCategory;
    }


    public class CourseCategoryEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        [StringLength(300)] public string Code { get; set; }
        [StringLength(600)] [Required] public string Title { get; set; }
        [Range(0, int.MaxValue)] [Required] public int DisplayOrder { get; set; }
        [Range(0, int.MaxValue)] [Required] public int EducationalCenterMainCourseCategoryId { get; set; }
        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }
        public int EducationalCenterId { get; set; }
    }


    public class CourseCategorySimpleViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public int ParentId { get; set; }

        public string Title { get; set; }
    }
}