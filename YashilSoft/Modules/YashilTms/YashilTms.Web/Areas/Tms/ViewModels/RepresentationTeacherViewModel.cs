using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilTms.Web.Areas.Tms.ViewModels
{
    public class RepresentationTeacherListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int? ParentId { get; set; }
        public int Id { get; set; }

        public int RepresentationId { get; set; }
        public string RepresentationTitle { get; set; }

        public string PersonTitle { get; set; }

        public int? CooperationType { get; set; }

        public int? FromDate { get; set; }

        public int? ToDate { get; set; }

        public string AccessLevelTitle { get; set; }
        public string PersonNationalCode { get; set; }
    }


    public class RepresentationTeacherEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        [Range(0, int.MaxValue)] [Required] public int RepresentationId { get; set; }
        [Range(0, int.MaxValue)] [Required] public int PersonId { get; set; }
        public int? CooperationType { get; set; }
        public int? FromDate { get; set; }
        public int? ToDate { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }
    }


    public class RepresentationTeacherSimpleViewModel : IBaseViewModel
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