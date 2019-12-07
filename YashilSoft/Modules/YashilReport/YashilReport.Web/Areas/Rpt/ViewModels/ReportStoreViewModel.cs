using System;
using System.Collections.Generic;
using Yashil.Common.Core.Interfaces;

namespace YashilReport.Web.Areas.Rpt.ViewModels
{
    public class ReportStoreListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string CssClass { get; set; }

        public string Picture { get; set; }

        public string Color { get; set; }

        public bool? Animation { get; set; }

        public string Description { get; set; }

        public string ReportKey { get; set; }

        public string DesignString { get; set; }

        public string ModuleKey { get; set; }

        public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
    }


    public class ReportStoreViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string CssClass { get; set; }

        public string Picture { get; set; }

        public string Color { get; set; }

        public bool? Animation { get; set; }

        public string Description { get; set; }

        public string ReportKey { get; set; }

        public string DesignString { get; set; }

        public string ModuleKey { get; set; }

        public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
    }


    public class ReportStoreEditModel : IBaseViewModel
    {
        public ReportStoreEditModel()
        {
            ConnectionStringEditModels = new List<ReportConnectionStringSimpleViewModel>();
        }

        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string CssClass { get; set; }

        public string Picture { get; set; }

        public string Color { get; set; }

        public bool? Animation { get; set; }

        public string Description { get; set; }

        public string ReportKey { get; set; }

        public string DesignString { get; set; }

        public string ModuleKey { get; set; }

        public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
        public List<ReportConnectionStringSimpleViewModel> ConnectionStringEditModels;
    }


    public class ReportStoreSimpleViewModel : IBaseViewModel
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