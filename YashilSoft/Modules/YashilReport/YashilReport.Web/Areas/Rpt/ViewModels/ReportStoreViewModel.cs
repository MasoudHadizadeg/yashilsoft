using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public byte[] ReportFile { get; set; }

        public string CssClass { get; set; }

        public byte[] Picture { get; set; }

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
        ReportStoreEditModel()
        {
            ConnectionStringIds = new List<int>();
        }

        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        [StringLength(300)] [Required] public string Title { get; set; }

        [StringLength(50)] public string CssClass { get; set; }

        public byte[] Picture { get; set; }

        [StringLength(50)] public string Color { get; set; }


        public bool? Animation { get; set; }

        public string Description { get; set; }

        [StringLength(300)] public string ReportKey { get; set; }

        [StringLength(300)] public string ModuleKey { get; set; }

        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
        public List<int> ConnectionStringIds { get; set; }
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