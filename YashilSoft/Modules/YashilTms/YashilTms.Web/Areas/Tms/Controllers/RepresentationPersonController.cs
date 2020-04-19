	 
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
	public class RepresentationPersonController : BaseController<RepresentationPerson ,int,RepresentationPersonListViewModel, RepresentationPersonEditModel,RepresentationPersonSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRepresentationPersonService _representationPersonService;
        public RepresentationPersonController(IRepresentationPersonService representationPersonService, IMapper mapper) : base(representationPersonService, mapper)
        {
            _mapper=mapper;
            _representationPersonService=representationPersonService;
        }
        
        [HttpGet("GetByRepresentationIdForList")]
        public async Task<LoadResult> GetByRepresentationIdForList(CustomDataSourceLoadOptions loadOptions, int representationId)
        {
            var representations = _representationPersonService.GetByRepresentationId(representationId);
            return await DataSourceLoader.LoadAsync(representations.ProjectTo<RepresentationPersonListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
    }
}      