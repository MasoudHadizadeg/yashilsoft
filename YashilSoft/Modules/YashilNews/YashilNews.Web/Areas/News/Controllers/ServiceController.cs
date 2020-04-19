

	 

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
                [HttpGet("GetByParentIdForList")]
        public async Task<LoadResult> GetByParentIdForList(CustomDataSourceLoadOptions loadOptions,int parentId)
        {
            var services = _serviceService.GetByParentId(parentId);
            return await DataSourceLoader.LoadAsync(services.ProjectTo<ServiceListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByAppEntityIdForList")]
        public async Task<LoadResult> GetByAppEntityIdForList(CustomDataSourceLoadOptions loadOptions,int appEntityId)
        {
            var services = _serviceService.GetByAppEntityId(appEntityId);
            return await DataSourceLoader.LoadAsync(services.ProjectTo<ServiceListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByCreateByForList")]
        public async Task<LoadResult> GetByCreateByForList(CustomDataSourceLoadOptions loadOptions,int createBy)
        {
            var services = _serviceService.GetByCreateBy(createBy);
            return await DataSourceLoader.LoadAsync(services.ProjectTo<ServiceListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByModifyByForList")]
        public async Task<LoadResult> GetByModifyByForList(CustomDataSourceLoadOptions loadOptions,int modifyBy)
        {
            var services = _serviceService.GetByModifyBy(modifyBy);
            return await DataSourceLoader.LoadAsync(services.ProjectTo<ServiceListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByApplicationIdForList")]
        public async Task<LoadResult> GetByApplicationIdForList(CustomDataSourceLoadOptions loadOptions,int applicationId)
        {
            var services = _serviceService.GetByApplicationId(applicationId);
            return await DataSourceLoader.LoadAsync(services.ProjectTo<ServiceListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByAccessLevelIdForList")]
        public async Task<LoadResult> GetByAccessLevelIdForList(CustomDataSourceLoadOptions loadOptions,int accessLevelId)
        {
            var services = _serviceService.GetByAccessLevelId(accessLevelId);
            return await DataSourceLoader.LoadAsync(services.ProjectTo<ServiceListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByCreatorOrganizationIdForList")]
        public async Task<LoadResult> GetByCreatorOrganizationIdForList(CustomDataSourceLoadOptions loadOptions,int creatorOrganizationId)
        {
            var services = _serviceService.GetByCreatorOrganizationId(creatorOrganizationId);
            return await DataSourceLoader.LoadAsync(services.ProjectTo<ServiceListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
             




        
    }
}      