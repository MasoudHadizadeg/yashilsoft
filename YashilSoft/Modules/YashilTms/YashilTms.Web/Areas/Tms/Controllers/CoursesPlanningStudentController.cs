	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using  YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
	public class CoursePlanningStudentController : BaseController<CoursePlanningStudent ,int,CoursePlanningStudentListViewModel, CoursePlanningStudentEditModel,CoursePlanningStudentSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICoursePlanningStudentService _coursePlanningStudentService;
        public CoursePlanningStudentController(ICoursePlanningStudentService coursePlanningStudentService, IMapper mapper) : base(coursePlanningStudentService, mapper)
        {
            _mapper=mapper;
            _coursePlanningStudentService=coursePlanningStudentService;
        }
    }
}      