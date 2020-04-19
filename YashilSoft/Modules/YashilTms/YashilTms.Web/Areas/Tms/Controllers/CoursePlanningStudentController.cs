	 
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
	public class CoursePlanningStudentController : BaseController<CoursePlanningStudent ,int,CoursePlanningStudentListViewModel, CoursePlanningStudentEditModel,CoursePlanningStudentSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICoursePlanningStudentService _coursePlanningStudentService;
        public CoursePlanningStudentController(ICoursePlanningStudentService coursePlanningStudentService, IMapper mapper) : base(coursePlanningStudentService, mapper)
        {
            _mapper=mapper;
            _coursePlanningStudentService=coursePlanningStudentService;
        }
              [HttpGet("GetByCustomFilterForList")]
        public async Task<LoadResult> GetByCustomFilterForList(CustomDataSourceLoadOptions loadOptions,  int? coursePlanningId, int? personId, int? studentStatus)
        {
            var coursePlanningStudents = _coursePlanningStudentService.GetByCustomFilter(coursePlanningId,personId,studentStatus);
            return await DataSourceLoader.LoadAsync(coursePlanningStudents.ProjectTo<CoursePlanningStudentListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCustomForSelect")]
        public async Task<LoadResult> GetByCustomForSelect(CustomDataSourceLoadOptions loadOptions,  int? coursePlanningId, int? personId, int? studentStatus)
        {
            var coursePlanningStudents = _coursePlanningStudentService.GetByCustomFilter(coursePlanningId,personId,studentStatus);
            return await DataSourceLoader.LoadAsync(coursePlanningStudents.ProjectTo<CoursePlanningStudentSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
  
    }
}      