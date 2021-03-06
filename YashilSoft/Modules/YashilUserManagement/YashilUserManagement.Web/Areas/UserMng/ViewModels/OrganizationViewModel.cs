using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{
    public class OrganizationListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public int? ParentId { get; set; }
        public string ParentTitle { get; set; }


        public int? Type { get; set; }

        public int? ProvinceId { get; set; }
    }


    public class OrganizationEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        [StringLength(600)] [Required] public string Title { get; set; }

        public string Description { get; set; }

        public bool? IsActive { get; set; }


        public int? ParentId { get; set; }


        public Int64? UniqueId { get; set; }

        public string CodePath { get; set; }


        public int? Type { get; set; }

        public int? ProvinceId { get; set; }
    }


    public class OrganizationSimpleViewModel : IBaseViewModel
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