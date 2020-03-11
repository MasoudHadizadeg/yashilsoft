	 
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Core.Classes;
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
        [HttpGet("GetByEducationalCenterIdForList")]
        public async Task<LoadResult> GetByEducationalCenterForList(CustomDataSourceLoadOptions loadOptions,
            int? educationalCenterId)
        {
            var representations = educationalCenterId.HasValue
                ? _courseService.GetByEducationalCenterId(educationalCenterId.Value)
                : _courseService.GetAll(true);

            return await DataSourceLoader.LoadAsync(representations.ProjectTo<CourseListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
    }
}      