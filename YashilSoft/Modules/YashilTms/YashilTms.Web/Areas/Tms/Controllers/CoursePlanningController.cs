	 
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Core.Classes;
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using  YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
	public class CoursePlanningController : BaseController<CoursePlanning ,int,CoursePlanningListViewModel, CoursePlanningEditModel,CoursePlanningSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICoursePlanningService _coursePlanningService;
        public CoursePlanningController(ICoursePlanningService coursePlanningService, IMapper mapper) : base(coursePlanningService, mapper)
        {
            _mapper=mapper;
            _coursePlanningService=coursePlanningService;
        }
              [HttpGet("GetByCustomFilterForList")]
        public async Task<LoadResult> GetByCustomFilterForList(CustomDataSourceLoadOptions loadOptions,  int? representationId, int? courseStatus, int? representationTeacherId, int? courseId, int? ageCategory, int? implementationType, int? courseType, int? runType, int? customGender)
        {
            var coursePlannings = _coursePlanningService.GetByCustomFilter(representationId,courseStatus,representationTeacherId,courseId,ageCategory,implementationType,courseType,runType,customGender);
            return await DataSourceLoader.LoadAsync(coursePlannings.ProjectTo<CoursePlanningListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCustomForSelect")]
        public async Task<LoadResult> GetByCustomForSelect(CustomDataSourceLoadOptions loadOptions,  int? representationId, int? courseStatus, int? representationTeacherId, int? courseId, int? ageCategory, int? implementationType, int? courseType, int? runType, int? customGender)
        {
            var coursePlannings = _coursePlanningService.GetByCustomFilter(representationId,courseStatus,representationTeacherId,courseId,ageCategory,implementationType,courseType,runType,customGender);
            return await DataSourceLoader.LoadAsync(coursePlannings.ProjectTo<CoursePlanningSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByRepresentationIdForList")]
        public async Task<LoadResult> GetByRepresentationIdForList(CustomDataSourceLoadOptions loadOptions,
            int? representationId)
        {
            var representations = representationId.HasValue
                ? _coursePlanningService.GetByRepresentationId(representationId.Value)
                : _coursePlanningService.GetAll(true);

            return await DataSourceLoader.LoadAsync(representations.ProjectTo<CoursePlanningListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCourseCategoryId")]
        public async Task<LoadResult> GetByCourseCategoryId(CustomDataSourceLoadOptions loadOptions, int courseCategoryId, bool hierarchical = true)
        {
            var courses = _coursePlanningService.GetByCourseCategoryId(courseCategoryId, hierarchical);
            return await DataSourceLoader.LoadAsync(courses.ProjectTo<CoursePlanningListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByMainCourseCategoryId")]
        public async Task<LoadResult> GetByMainCourseCategoryId(CustomDataSourceLoadOptions loadOptions, int educationalCenterMainCourseCategoryId)
        {
            var courses = _coursePlanningService.GetByMainCourseCategoryId(educationalCenterMainCourseCategoryId);
            return await DataSourceLoader.LoadAsync(courses.ProjectTo<CoursePlanningListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

    }
}      