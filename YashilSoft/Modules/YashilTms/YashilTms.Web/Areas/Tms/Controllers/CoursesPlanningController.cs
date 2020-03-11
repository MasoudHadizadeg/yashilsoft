	 
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
	public class CoursesPlanningController : BaseController<CoursesPlanning ,int,CoursesPlanningListViewModel, CoursesPlanningEditModel,CoursesPlanningSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICoursesPlanningService _coursesPlanningService;
        public CoursesPlanningController(ICoursesPlanningService coursesPlanningService, IMapper mapper) : base(coursesPlanningService, mapper)
        {
            _mapper=mapper;
            _coursesPlanningService=coursesPlanningService;
        }
        [HttpGet("GetByRepresentationIdForList")]
        public async Task<LoadResult> GetByRepresentationIdForList(CustomDataSourceLoadOptions loadOptions,
            int? representationId)
        {
            var representations = representationId.HasValue
                ? _coursesPlanningService.GetByRepresentationId(representationId.Value)
                : _coursesPlanningService.GetAll(true);

            return await DataSourceLoader.LoadAsync(representations.ProjectTo<CoursesPlanningListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
    }
}      