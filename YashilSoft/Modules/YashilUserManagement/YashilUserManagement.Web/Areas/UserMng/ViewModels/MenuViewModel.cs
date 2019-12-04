using System;
using Yashil.Common.Core.Interfaces;

namespace YashilUserManagement.Web.Areas.UserMng.ViewModels
{
    public class MenuListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }


        public string Path { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public string Class { get; set; }

        public string Badge { get; set; }

        public string BadgeClass { get; set; }

        public bool? IsExternalLink { get; set; }

        public int? ParentId { get; set; }
        public string ParentTitle { get; set; }

        public int? ResourceId { get; set; }
        public string ResourceTitle { get; set; }

        public bool IsVirtual { get; set; }

        public int? OrderNo { get; set; }
    }


    public class MenuViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public string Path { get; set; }


        public string Icon { get; set; }

        public string Class { get; set; }

        public string Badge { get; set; }

        public string BadgeClass { get; set; }

        public bool? IsExternalLink { get; set; }

        public int? ParentId { get; set; }
        public string ParentTitle { get; set; }

        public int? ResourceId { get; set; }
        public string ResourceTitle { get; set; }

        public bool IsVirtual { get; set; }

        public int? OrderNo { get; set; }
    }


    public class MenuEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public string Path { get; set; }


        public string Icon { get; set; }

        public string Class { get; set; }

        public string Badge { get; set; }

        public string BadgeClass { get; set; }

        public bool? IsExternalLink { get; set; }

        public int? ParentId { get; set; }
        public string ParentTitle { get; set; }

        public int? ResourceId { get; set; }
        public string ResourceTitle { get; set; }

        public bool IsVirtual { get; set; }

        public int? OrderNo { get; set; }
    }


    public class MenuSimpleViewModel : IBaseViewModel
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