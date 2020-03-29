using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilTms.Web.Areas.Tms.ViewModels
{
    public class AdditionalUserPropListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string UserTitle { get; set; }

        public int EducationalCenterId { get; set; }

        public string RepresentationTitle { get; set; }
    }


    public class AdditionalUserPropEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }
        [Range(0, int.MaxValue)] [Required] public int UserId { get; set; }
        [Range(0, int.MaxValue)] [Required] public int EducationalCenterId { get; set; }
        public int? RepresentationId { get; set; }
    }


    public class AdditionalUserPropSimpleViewModel : IBaseViewModel
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