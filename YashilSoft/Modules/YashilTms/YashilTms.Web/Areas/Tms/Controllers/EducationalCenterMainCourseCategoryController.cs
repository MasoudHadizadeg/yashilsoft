using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.CustomViewModels;
using Yashil.Core.Entities;
using YashilTms.Core.Services;
using YashilTms.Web.Areas.Tms.ViewModels;

namespace YashilTms.Web.Areas.Tms.Controllers
{
    public class EducationalCenterMainCourseCategoryController : BaseController<EducationalCenterMainCourseCategory, int
        , EducationalCenterMainCourseCategoryListViewModel, EducationalCenterMainCourseCategoryEditModel,
        EducationalCenterMainCourseCategorySimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IEducationalCenterMainCourseCategoryService _educationalCenterMainCourseCategoryService;
        private readonly IMainCourseCategoryService _mainCourseCategoryService;

        public EducationalCenterMainCourseCategoryController(
            IEducationalCenterMainCourseCategoryService educationalCenterMainCourseCategoryService, IMapper mapper,
            IMainCourseCategoryService mainCourseCategoryService) : base(educationalCenterMainCourseCategoryService,
            mapper)
        {
            _mapper = mapper;
            _mainCourseCategoryService = mainCourseCategoryService;
            _educationalCenterMainCourseCategoryService = educationalCenterMainCourseCategoryService;
        }

        [HttpGet("GetEducationalCenterMainCourseCategorysNotAssignedToEducationalCenterAsync")]
        public async Task<LoadResult> GetEducationalCenterMainCourseCategorysNotAssignedToEducationalCenterAsync(
            CustomDataSourceLoadOptions loadOptions, int id)
        {
            var entities = _mainCourseCategoryService.GetMainCourseCategoryNotAssignedToEducationalCenterAsync(id);
            return await DataSourceLoader.LoadAsync(entities.ProjectTo<MainCourseCategorySimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetEducationalCenterMainCourseCategorysAssignedToEducationalCenterAsync")]
        public async Task<LoadResult> GetEducationalCenterMainCourseCategorysAssignedToEducationalCenterAsync(
            CustomDataSourceLoadOptions loadOptions, int id)
        {
            var entities = _educationalCenterMainCourseCategoryService.GetMainCourseCategoriesByEducationalCenterId(id);
            return await DataSourceLoader.LoadAsync(entities.ProjectTo<EducationalCenterMainCourseCategorySimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpPost("AssignSelectedItemsToEducationalCenter")]
        public async Task<bool> AssignSelectedItemsToEducationalCenter(AssignableListEditModel assignableListEditModel)
        {
            return await _educationalCenterMainCourseCategoryService.AssignSelectedItemsToEducationalCenter(
                new List<int>(assignableListEditModel.SelectedItems), assignableListEditModel.GroupId,
                assignableListEditModel.Assign);
        }


        [HttpPut("PutEntityCustom")]
        public  HttpResponseMessage PutEntityCustom(EducationalCenterMainCourseCategoryCustomEditModel editModel)
        {
            var entity = new EducationalCenterMainCourseCategory
            {
                DisplayOrder = editModel.EditModel.DisplayOrder,
                Id = editModel.EditModel.Id
            };
            _educationalCenterMainCourseCategoryService.Update(entity, entity.Id, new List<string> {"DisplayOrder"},
                true, true);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet("GetByEducationalCenterId/{id}")]
        public async Task<List<EducationalCenterMainCourseCategorySimpleViewModel>> GetByEducationalCenterId(int id)
        {
            var mainCourseCategories = _educationalCenterMainCourseCategoryService.GetMainCourseCategoriesByEducationalCenterId(id);
            return await mainCourseCategories.ProjectTo<EducationalCenterMainCourseCategorySimpleViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}