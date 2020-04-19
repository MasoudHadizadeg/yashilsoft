	 
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
	public class CoursePlanningController : BaseController<CoursePlanning ,int,CoursePlanningListViewModel, CoursePlanningEditModel,CoursePlanningSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICoursePlanningService _coursePlanningService;
        public CoursePlanningController(ICoursePlanningService coursePlanningService, IMapper mapper) : base(coursePlanningService, mapper)
        {
            _mapper=mapper;
            _coursePlanningService=coursePlanningService;
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
        public async Task<LoadResult> GetByCourseCategoryId(CustomDataSourceLoadOptions loadOptions,int representationId, int courseCategoryId, bool hierarchical = true)
        {
            var courses = _coursePlanningService.GetByCourseCategoryId(courseCategoryId, representationId, hierarchical);
            return await DataSourceLoader.LoadAsync(courses.ProjectTo<CoursePlanningListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByMainCourseCategoryId")]
        public async Task<LoadResult> GetByMainCourseCategoryId(CustomDataSourceLoadOptions loadOptions, int representationId, int educationalCenterMainCourseCategoryId)
        {
            var courses = _coursePlanningService.GetByMainCourseCategoryId(educationalCenterMainCourseCategoryId, representationId);
            return await DataSourceLoader.LoadAsync(courses.ProjectTo<CoursePlanningListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
    }
}      