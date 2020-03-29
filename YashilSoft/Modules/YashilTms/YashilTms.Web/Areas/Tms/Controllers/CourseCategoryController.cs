using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
    public class CourseCategoryController : BaseController<CourseCategory, int, CourseCategoryListViewModel,
        CourseCategoryEditModel, CourseCategorySimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICourseCategoryService _courseCategoryService;
        private readonly IEducationalCenterMainCourseCategoryService _educationalCenterMainCourseCategoryService;

        public CourseCategoryController(ICourseCategoryService courseCategoryService, IMapper mapper,
            IEducationalCenterMainCourseCategoryService educationalCenterMainCourseCategoryService) : base(
            courseCategoryService, mapper)
        {
            _mapper = mapper;
            _educationalCenterMainCourseCategoryService = educationalCenterMainCourseCategoryService;
            _courseCategoryService = courseCategoryService;
        }

        [HttpGet("GetByEducationalCenterForList")]
        public async Task<LoadResult> GetByEducationalCenterForList(CustomDataSourceLoadOptions loadOptions,
            int? educationalCenterId)
        {
            var representations = educationalCenterId.HasValue
                ? _courseCategoryService.GetByEducationalCenterId(educationalCenterId.Value)
                : _courseCategoryService.GetAll(true);

            return await DataSourceLoader.LoadAsync(
                representations.ProjectTo<CourseCategoryListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetByEducationalCenterMainCourseCategoryId/{educationalCenterMainCourseCategoryId}")]
        public Task<List<CourseCategorySimpleViewModel>> GetByEducationalCenterMainCourseCategoryId(
            int educationalCenterMainCourseCategoryId)
        {
            var courseCategories = _courseCategoryService.GetByEducationalCenterMainCourseCategoryId(educationalCenterMainCourseCategoryId);
            return courseCategories.ProjectTo<CourseCategorySimpleViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        [HttpGet("GetMainCourseCategoriesByEducationalCenterId")]
        public List<CourseCategoryListViewModel> GetMainCourseCategoriesByEducationalCenterId(int? educationalCenterId)
        {
            var mainCourseCategories = _educationalCenterMainCourseCategoryService.GetMainCourseCategoriesByEducationalCenterId(educationalCenterId);
            return GetMainAndSubCategories(mainCourseCategories);
        }


        [HttpGet("GetMainCourseCategoryByRepresentationId")]
        public List<CourseCategoryListViewModel> GetMainCourseCategoryByRepresentationId(int representationId)
        {
            var mainCourseCategories = _educationalCenterMainCourseCategoryService.GetMainCourseCategoryByRepresentationId(representationId);
            return GetMainAndSubCategories(mainCourseCategories);
        }
       
        private List<CourseCategoryListViewModel> GetMainAndSubCategories(IQueryable<EducationalCenterMainCourseCategory> mainCourseCategories)
        {
            var educationalCenterCategories = mainCourseCategories.Select(x =>
                new CourseCategoryListViewModel
                {
                    Title = x.MainCourseCategory.Title,
                    Id = x.MainCourseCategoryId,
                    IsMainCourseCategory = true,
                    ParentId = null,
                    ViewModelId = x.MainCourseCategoryId,
                    EducationalCenterMainCourseCategoryId = x.Id
                }).ToList();
            foreach (var educationalCenterMainCourseCategory in mainCourseCategories)
            {
                var courseCategories = educationalCenterMainCourseCategory.CourseCategory.Select(x =>
                    new CourseCategoryListViewModel
                    {
                        Title = x.Title,
                        Id = x.Id,
                        IsMainCourseCategory = false,
                        ParentId = x.ParentId ?? educationalCenterMainCourseCategory.MainCourseCategoryId,
                        DisplayOrder = x.DisplayOrder,
                        EducationalCenterMainCourseCategoryId = educationalCenterMainCourseCategory.Id
                    });
                educationalCenterCategories.AddRange(courseCategories);
            }

            return educationalCenterCategories;

        }


    }
}