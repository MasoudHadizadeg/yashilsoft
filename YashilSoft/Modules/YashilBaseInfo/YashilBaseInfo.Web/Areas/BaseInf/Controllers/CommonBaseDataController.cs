	 
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using  YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf.Controllers
{
	public class CommonBaseDataController : BaseController<CommonBaseData ,int,CommonBaseDataListViewModel, CommonBaseDataEditModel,CommonBaseDataSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly ICommonBaseDataService _commonBaseDataService;
        public CommonBaseDataController(ICommonBaseDataService commonBaseDataService, IMapper mapper) : base(commonBaseDataService, mapper)
        {
            _mapper=mapper;
            _commonBaseDataService=commonBaseDataService;
        }
        [HttpGet("GetByKeyName")]
        public Task<List<CommonBaseDataSimpleViewModel>> GetByKeyName(string keyName)
        {
            return _commonBaseDataService.GetByKeyName(keyName).ProjectTo<CommonBaseDataSimpleViewModel>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}      