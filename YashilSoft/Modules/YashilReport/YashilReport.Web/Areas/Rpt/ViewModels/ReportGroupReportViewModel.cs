using System;
using Yashil.Common.Core.Interfaces;

namespace YashilReport.Web.Areas.Rpt.ViewModels
{
    public class ReportGroupReportListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public int ReportStoreId { get; set; }
        public string ReportStoreTitle { get; set; }

        public int ReportGroupId { get; set; }
        public string ReportGroupTitle { get; set; }
    }


    public class ReportGroupReportViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public int ReportStoreId { get; set; }
        public string ReportStoreTitle { get; set; }

        public int ReportGroupId { get; set; }
        public string ReportGroupTitle { get; set; }
    }


    public class ReportGroupReportEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public int ReportStoreId { get; set; }
        public string ReportStoreTitle { get; set; }

        public int ReportGroupId { get; set; }
        public string ReportGroupTitle { get; set; }
    }


    public class ReportGroupReportSimpleViewModel : IBaseViewModel
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