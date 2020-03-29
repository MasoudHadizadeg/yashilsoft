using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilTms.Web.Areas.Tms.ViewModels
{
    public class EducationalCenterMainCourseCategoryListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string EducationalCenterTitle { get; set; }

        public string MainCourseCategoryTitle { get; set; }

        public int DisplayOrder { get; set; }
    }


    public class EducationalCenterMainCourseCategoryEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        [Range(0, int.MaxValue)] [Required] public int EducationalCenterId { get; set; }
        [Range(0, int.MaxValue)] [Required] public int MainCourseCategoryId { get; set; }
        [Range(0, int.MaxValue)] [Required] public int DisplayOrder { get; set; }
        public string Description { get; set; }
    }

    public  class EducationalCenterMainCourseCategoryCustomEditModelItem
    {
        public EducationalCenterMainCourseCategoryCustomEditModelItem() { }
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int Id { get; set; }
        [Range(0, int.MaxValue)] [Required] public int DisplayOrder { get; set; }
    }
    public class EducationalCenterMainCourseCategoryCustomEditModel 
    {
        public List<string> ChangedProps { get; set; }
        public EducationalCenterMainCourseCategoryCustomEditModelItem EditModel { get; set; }
    }

    public class EducationalCenterMainCourseCategorySimpleViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        public int MainCourseCategoryId { get; set; }
        public int EducationalCenterId { get; set; }
        public int DisplayOrder { get; set; }
        public string Title { get; set; }
    }
}