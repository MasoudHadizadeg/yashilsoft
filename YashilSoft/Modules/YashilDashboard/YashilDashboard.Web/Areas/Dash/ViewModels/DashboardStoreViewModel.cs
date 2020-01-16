using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilDashboard.Web.Areas.Dash.ViewModels
{
    public class DashboardStoreListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string AccessLevelTitle { get; set; }
    }


    public class DashboardStoreViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public byte[] DashboardFile { get; set; }

        public string CssClass { get; set; }

        public byte[] Picture { get; set; }

        public string Color { get; set; }

        public bool? Animation { get; set; }

        public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
    }


    public class DashboardStoreEditModel : IBaseViewModel
    {
        public DashboardStoreEditModel()
        {
            ConnectionStringIds = new List<int>();
        }

        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        [StringLength(300)] public string Code { get; set; }

        [StringLength(300)] [Required] public string Title { get; set; }


        public string Description { get; set; }

        [StringLength(50)] public string CssClass { get; set; }


        public byte[] Picture { get; set; }

        [StringLength(50)] public string Color { get; set; }


        public bool? Animation { get; set; }

        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
        public List<int> ConnectionStringIds { get; set; }
    }


    public class DashboardStoreSimpleViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Title { get; set; }
    }

    public class SimpleConnectionString
    {
        public int Id { get; set; }
    }
}