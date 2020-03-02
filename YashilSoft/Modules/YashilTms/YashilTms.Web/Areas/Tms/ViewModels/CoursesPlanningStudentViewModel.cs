using System;
using System.ComponentModel.DataAnnotations;
using Yashil.Common.Core.Interfaces;

namespace YashilTms.Web.Areas.Tms.ViewModels
{
    public class CoursesPlanningStudentListViewModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        public string Code { get; set; }

        public int CoursesPlanningId { get; set; }
        public string CoursesPlanningTitle { get; set; }

        public int PersonId { get; set; }
        public string PersonTitle { get; set; }

        public double Score { get; set; }

        public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
    }

    public class CoursesPlanningStudentEditModel : IBaseViewModel
    {
        public int ViewModelId
        {
            get => Id;
            set => Id = value;
        }

        public int Id { get; set; }

        [StringLength(300)] public string Code { get; set; }

        [Range(0, int.MaxValue)] [Required] public int CoursesPlanningId { get; set; }
        public string CoursesPlanningTitle { get; set; }

        [Range(0, int.MaxValue)] [Required] public int PersonId { get; set; }
        public string PersonTitle { get; set; }

        [Required] public double Score { get; set; }


        public string Description { get; set; }

        [Range(0, int.MaxValue)] [Required] public int AccessLevelId { get; set; }
        public string AccessLevelTitle { get; set; }
    }

    public class CoursesPlanningStudentSimpleViewModel : IBaseViewModel
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