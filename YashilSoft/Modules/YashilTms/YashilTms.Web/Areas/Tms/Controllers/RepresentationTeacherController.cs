	 
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
	public class RepresentationTeacherController : BaseController<RepresentationTeacher ,int,RepresentationTeacherListViewModel, RepresentationTeacherEditModel,RepresentationTeacherSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRepresentationTeacherService _representationTeacherService;
        public RepresentationTeacherController(IRepresentationTeacherService representationTeacherService, IMapper mapper) : base(representationTeacherService, mapper)
        {
            _mapper=mapper;
            _representationTeacherService=representationTeacherService;
        }
              [HttpGet("GetByCustomFilterForList")]
        public async Task<LoadResult> GetByCustomFilterForList(CustomDataSourceLoadOptions loadOptions,  int? personId)
        {
            var representationTeachers = _representationTeacherService.GetByCustomFilter(personId);
            return await DataSourceLoader.LoadAsync(representationTeachers.ProjectTo<RepresentationTeacherListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCustomForSelect")]
        public async Task<LoadResult> GetByCustomForSelect(CustomDataSourceLoadOptions loadOptions,  int? personId)
        {
            var representationTeachers = _representationTeacherService.GetByCustomFilter(personId);
            return await DataSourceLoader.LoadAsync(representationTeachers.ProjectTo<RepresentationTeacherSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
  
    }
}      