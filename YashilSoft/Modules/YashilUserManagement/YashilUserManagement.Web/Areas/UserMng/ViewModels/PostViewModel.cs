using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{
    public class PostListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string JobTitle { get; set; }

        public string ParentTitle { get; set; }

        public bool IsVirtual { get; set; }

        public string AccessLevelTitle { get; set; }
    }


    public class PostEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        [StringLength(300)] [Required] public string Code { get; set; }
        [StringLength(600)] [Required] public string Title { get; set; }
        public int? JobId { get; set; }
        [Range(0, int.MaxValue)] public int? ParentId { get; set; }
        public bool IsVirtual { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }
    }


    public class PostSimpleViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int? ParentId { get; set; }
    }
}