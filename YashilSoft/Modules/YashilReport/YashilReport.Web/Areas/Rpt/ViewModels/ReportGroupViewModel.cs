using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilReport.Web.Areas.Rpt.ViewModels
{
    public class ReportGroupListViewModel : IBaseViewModel
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


    public class ReportGroupViewModel : IBaseViewModel
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


    public class ReportGroupEditModel : IBaseViewModel
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

        [Range(0, int.MaxValue)]
        [Required]

        public int AccessLevelId { get; set; }

    }

    public class ReportGroupSimpleViewModel : IBaseViewModel
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
