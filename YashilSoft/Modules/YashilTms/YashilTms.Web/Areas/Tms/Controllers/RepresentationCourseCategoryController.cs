	 
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
	public class RepresentationCourseCategoryController : BaseController<RepresentationCourseCategory ,int,RepresentationCourseCategoryListViewModel, RepresentationCourseCategoryEditModel,RepresentationCourseCategorySimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRepresentationCourseCategoryService _representationCourseCategoryService;
        public RepresentationCourseCategoryController(IRepresentationCourseCategoryService representationCourseCategoryService, IMapper mapper) : base(representationCourseCategoryService, mapper)
        {
            _mapper=mapper;
            _representationCourseCategoryService=representationCourseCategoryService;
        }
              [HttpGet("GetByCustomFilterForList")]
        public async Task<LoadResult> GetByCustomFilterForList(CustomDataSourceLoadOptions loadOptions,  int? representationId, int? courseCategoryId)
        {
            var representationCourseCategorys = _representationCourseCategoryService.GetByCustomFilter(representationId,courseCategoryId);
            return await DataSourceLoader.LoadAsync(representationCourseCategorys.ProjectTo<RepresentationCourseCategoryListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCustomForSelect")]
        public async Task<LoadResult> GetByCustomForSelect(CustomDataSourceLoadOptions loadOptions,  int? representationId, int? courseCategoryId)
        {
            var representationCourseCategorys = _representationCourseCategoryService.GetByCustomFilter(representationId,courseCategoryId);
            return await DataSourceLoader.LoadAsync(representationCourseCategorys.ProjectTo<RepresentationCourseCategorySimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
  
    }
}      