	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using  YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
	public class CoursesPlanningStudentController : BaseController<CoursesPlanningStudent ,int,CoursesPlanningStudentListViewModel, CoursesPlanningStudentEditModel,CoursesPlanningStudentSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICoursesPlanningStudentService _coursesPlanningStudentService;
        public CoursesPlanningStudentController(ICoursesPlanningStudentService coursesPlanningStudentService, IMapper mapper) : base(coursesPlanningStudentService, mapper)
        {
            _mapper=mapper;
            _coursesPlanningStudentService=coursesPlanningStudentService;
        }
    }
}      