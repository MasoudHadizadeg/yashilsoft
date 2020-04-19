	 
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Core.Classes;
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilNews.Core.Services;
using  YashilNews.Web.Areas.News.ViewModels;

namespace YashilNews.Web.Areas.News.Controllers
{
	public class ServiceController : BaseController<Service ,int,ServiceListViewModel, ServiceEditModel,ServiceSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService, IMapper mapper) : base(serviceService, mapper)
        {
            _mapper=mapper;
            _serviceService=serviceService;
        }
              [HttpGet("GetByCustomFilterForList")]
        public async Task<LoadResult> GetByCustomFilterForList(CustomDataSourceLoadOptions loadOptions,  int? parentId, int? appEntityId)
        {
            var services = _serviceService.GetByCustomFilter(parentId,appEntityId);
            return await DataSourceLoader.LoadAsync(services.ProjectTo<ServiceListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCustomForSelect")]
        public async Task<LoadResult> GetByCustomForSelect(CustomDataSourceLoadOptions loadOptions,  int? parentId, int? appEntityId)
        {
            var services = _serviceService.GetByCustomFilter(parentId,appEntityId);
            return await DataSourceLoader.LoadAsync(services.ProjectTo<ServiceSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
  
    }
}      