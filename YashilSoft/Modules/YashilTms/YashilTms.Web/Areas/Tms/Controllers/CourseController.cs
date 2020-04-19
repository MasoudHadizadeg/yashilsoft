
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
using YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
    public class CourseController : BaseController<Course, int, CourseListViewModel, CourseEditModel, CourseSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService, IMapper mapper) : base(courseService, mapper)
        {
            _mapper = mapper;
            _courseService = courseService;
        }
        [HttpGet("GetByEducationalCenterIdForList")]
        public async Task<LoadResult> GetByEducationalCenterForList(CustomDataSourceLoadOptions loadOptions,
            int? educationalCenterId)
        {
            var courses = educationalCenterId.HasValue
                ? _courseService.GetByEducationalCenterId(educationalCenterId.Value)
                : _courseService.GetAll(true);

            return await DataSourceLoader.LoadAsync(courses.ProjectTo<CourseListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetByRepresentationIdForSelect")]
        public async Task<LoadResult> GetByRepresentationIdForSelect(CustomDataSourceLoadOptions loadOptions, int representationId)
        {
            var courses = _courseService.GetByRepresentationId(representationId);

            return await DataSourceLoader.LoadAsync(courses.ProjectTo<CourseSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCourseCategoryId")]
        public async Task<LoadResult> GetByCourseCategoryId(CustomDataSourceLoadOptions loadOptions, int courseCategoryId, bool hierarchical = true)
        {
            var courses = _courseService.GetByCourseCategoryId(courseCategoryId, hierarchical);
            return await DataSourceLoader.LoadAsync(courses.ProjectTo<CourseListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetRepresentationCourseByCategoryId")]
        public async Task<LoadResult> GetRepresentationCourseByCategoryId(CustomDataSourceLoadOptions loadOptions, int representationId, int courseCategoryId, bool hierarchical = true)
        {
            var courses = _courseService.GetRepresentationCourseByCategoryId(representationId,courseCategoryId, hierarchical);
            return await DataSourceLoader.LoadAsync(courses.ProjectTo<CourseListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetByMainCourseCategoryId")]
        public async Task<LoadResult> GetByMainCourseCategoryId(CustomDataSourceLoadOptions loadOptions,int educationalCenterMainCourseCategoryId)
        {
            var courses = _courseService.GetByMainCourseCategoryId(educationalCenterMainCourseCategoryId);
            return await DataSourceLoader.LoadAsync(courses.ProjectTo<CourseListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
    }
}