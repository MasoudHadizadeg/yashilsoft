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
    public class CourseCategoryController : BaseController<CourseCategory, int, CourseCategoryListViewModel, CourseCategoryEditModel, CourseCategorySimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryService _courseCategoryService;
        public CourseCategoryController(ICourseCategoryService courseCategoryService, IMapper mapper) : base(courseCategoryService, mapper)
        {
            _mapper = mapper;
            _courseCategoryService = courseCategoryService;
        }
        [HttpGet("GetByEducationalCenterIdForList")]
        public async Task<LoadResult> GetByEducationalCenterForList(CustomDataSourceLoadOptions loadOptions,
            int? educationalCenterId)
        {
            var representations = educationalCenterId.HasValue
                ? _courseCategoryService.GetByEducationalCenterId(educationalCenterId.Value)
                : _courseCategoryService.GetAll(true);

            return await DataSourceLoader.LoadAsync(representations.ProjectTo<CourseCategoryListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
    }
}