using System;
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
    public class RepresentationController : BaseController<Representation, int, RepresentationListViewModel,
        RepresentationEditModel, RepresentationSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRepresentationService _representationService;

        public RepresentationController(IRepresentationService representationService, IMapper mapper) : base(
            representationService, mapper)
        {
            _mapper = mapper;
            _representationService = representationService;
        }

        [HttpGet("GetByEducationalCenter")]
        public async Task<LoadResult> GetByEducationalCenter(CustomDataSourceLoadOptions loadOptions,
            int? educationalCenterId)
        {
            var representations = educationalCenterId.HasValue
                ? _representationService.GetByEducationalCenterId(educationalCenterId.Value)
                : _representationService.GetAll(true);

            return await DataSourceLoader.LoadAsync(
                representations.ProjectTo<RepresentationSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetByEducationalCenterIdForList")]
        public async Task<LoadResult> GetByEducationalCenterForList(CustomDataSourceLoadOptions loadOptions,
            int? educationalCenterId)
        {
            var representations = educationalCenterId.HasValue
                ? _representationService.GetByEducationalCenterId(educationalCenterId.Value)
                : _representationService.GetAll(true);

            return await DataSourceLoader.LoadAsync(representations.ProjectTo<RepresentationListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        protected override void CustomMapBeforeInsert(RepresentationEditModel editModel, Representation entity)
        {
            foreach (var courseCategoryId in editModel.CourseCategories)
            {
                entity.RepresentationCourseCategory.Add(new RepresentationCourseCategory
                {
                    CourseCategoryId = courseCategoryId
                });
            }
        }
    }
}