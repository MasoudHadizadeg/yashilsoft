using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilDms.Web.Areas.Dms.ViewModels
{
    public class DocumentCategoryListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ParentTitle { get; set; }

        public string AppEntityTitle { get; set; }

        public int? DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public bool IsCategorized { get; set; }
    }


    public class DocumentCategoryEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        [StringLength(100)] [Required] public string Title { get; set; }
        public int? ParentId { get; set; }
        [Range(0, int.MaxValue)] 
        [Required] public int AppEntityId { get; set; }
        public int? DisplayOrder { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsCategorized { get; set; }
        public string AppEntityTitle { get; set; }

    }

    public class DocumentCategorySimpleViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int ParentId { get; set; }
    }
}