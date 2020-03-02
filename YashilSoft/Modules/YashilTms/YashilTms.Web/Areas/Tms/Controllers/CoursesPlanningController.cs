	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using  YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
	public class CoursesPlanningController : BaseController<CoursesPlanning ,int,CoursesPlanningListViewModel, CoursesPlanningEditModel,CoursesPlanningSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICoursesPlanningService _coursesPlanningService;
        public CoursesPlanningController(ICoursesPlanningService coursesPlanningService, IMapper mapper) : base(coursesPlanningService, mapper)
        {
            _mapper=mapper;
            _coursesPlanningService=coursesPlanningService;
        }
    }
}      