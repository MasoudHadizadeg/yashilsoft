	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using  YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
	public class CourseCategoryController : BaseController<CourseCategory ,int,CourseCategoryListViewModel, CourseCategoryEditModel,CourseCategorySimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryService _courseCategoryService;
        public CourseCategoryController(ICourseCategoryService courseCategoryService, IMapper mapper) : base(courseCategoryService, mapper)
        {
            _mapper=mapper;
            _courseCategoryService=courseCategoryService;
        }
    }
}      