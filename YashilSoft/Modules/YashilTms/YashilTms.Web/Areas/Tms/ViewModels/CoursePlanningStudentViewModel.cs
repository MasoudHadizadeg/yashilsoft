using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;
namespace YashilTms.Web.Areas.Tms.ViewModels
{

    public class CoursePlanningStudentListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int Id { get; set; }

        public string Code { get; set; }

        public string CoursePlanningTitle { get; set; }

        public string PersonTitle { get; set; }
        public string NationalCode { get; set; }
        public double Score { get; set; }

        public string AccessLevelTitle { get; set; }

    }


    public class CoursePlanningStudentEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }
        public int Id { get; set; }
        [StringLength(300)] public string Code { get; set; }
        [Range(0, int.MaxValue)]
        [Required] public int CoursePlanningId { get; set; }
        [Range(0, int.MaxValue)]
        [Required] public int PersonId { get; set; }

        [Required] public double Score { get; set; }
        [Range(0, int.MaxValue)]
        [Required] public int AccessLevelId { get; set; }
    }





    public class CoursePlanningStudentSimpleViewModel : IBaseViewModel
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
