using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilReport.Web.Areas.Rpt.ViewModels
{
    public class UserReportListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public int UserId { get; set; }
        public string UserTitle { get; set; }

        public int ReportId { get; set; }
        public string ReportTitle { get; set; }
    }


    public class UserReportViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public int UserId { get; set; }
        public string UserTitle { get; set; }

        public int ReportId { get; set; }
        public string ReportTitle { get; set; }
    }


    public class UserReportEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        [Range(0, int.MaxValue)] [Required] public int UserId { get; set; }
        public string UserTitle { get; set; }

        [Range(0, int.MaxValue)] [Required] public int ReportId { get; set; }
        public string ReportTitle { get; set; }
    }


    public class UserReportSimpleViewModel : IBaseViewModel
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