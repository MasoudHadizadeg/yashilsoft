using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilDashboard.Web.Areas.Dash.ViewModels
{

    public class DashboardGroupListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int Id { get; set; }

        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string Description { get; set; }

    }


    public class DashboardGroupViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int Id { get; set; }

        public string Title { get; set; }
        public string EnglishTitle { get; set; }
        public string Description { get; set; }

    }


    public class DashboardGroupEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        [StringLength(400)]
        [Required]

        public string Title { get; set; }

        [StringLength(400)]
        [Required]
        public string EnglishTitle { get; set; }

        public string Description { get; set; }

    }


    public class DashboardGroupSimpleViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int Id { get; set; }

        public string Title { get; set; }
        public string EnglishTitle { get; set; }
    }

}
