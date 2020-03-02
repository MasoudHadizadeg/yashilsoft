	 
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using  YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
	public class CourseController : BaseController<Course ,int,CourseListViewModel, CourseEditModel,CourseSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService, IMapper mapper) : base(courseService, mapper)
        {
            _mapper=mapper;
            _courseService=courseService;
        }
        [HttpGet("GetTopic")]
        public string GetTopic(int id)
        {
            string course = _courseService.GetTopic(id);
        }
    }
}      