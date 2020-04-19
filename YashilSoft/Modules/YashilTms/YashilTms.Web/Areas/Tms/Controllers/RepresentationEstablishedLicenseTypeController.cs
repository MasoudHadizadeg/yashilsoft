	 
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
	public class RepresentationEstablishedLicenseTypeController : BaseController<RepresentationEstablishedLicenseType ,int,RepresentationEstablishedLicenseTypeListViewModel, RepresentationEstablishedLicenseTypeEditModel,RepresentationEstablishedLicenseTypeSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRepresentationEstablishedLicenseTypeService _representationEstablishedLicenseTypeService;
        public RepresentationEstablishedLicenseTypeController(IRepresentationEstablishedLicenseTypeService representationEstablishedLicenseTypeService, IMapper mapper) : base(representationEstablishedLicenseTypeService, mapper)
        {
            _mapper=mapper;
            _representationEstablishedLicenseTypeService=representationEstablishedLicenseTypeService;
        }
              [HttpGet("GetByCustomFilterForList")]
        public async Task<LoadResult> GetByCustomFilterForList(CustomDataSourceLoadOptions loadOptions,  int? representationId, int? establishedLicenseType)
        {
            var representationEstablishedLicenseTypes = _representationEstablishedLicenseTypeService.GetByCustomFilter(representationId,establishedLicenseType);
            return await DataSourceLoader.LoadAsync(representationEstablishedLicenseTypes.ProjectTo<RepresentationEstablishedLicenseTypeListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCustomForSelect")]
        public async Task<LoadResult> GetByCustomForSelect(CustomDataSourceLoadOptions loadOptions,  int? representationId, int? establishedLicenseType)
        {
            var representationEstablishedLicenseTypes = _representationEstablishedLicenseTypeService.GetByCustomFilter(representationId,establishedLicenseType);
            return await DataSourceLoader.LoadAsync(representationEstablishedLicenseTypes.ProjectTo<RepresentationEstablishedLicenseTypeSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
  
    }
}      