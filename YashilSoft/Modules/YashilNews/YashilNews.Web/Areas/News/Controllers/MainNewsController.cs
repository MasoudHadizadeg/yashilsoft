

	 

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
	public class MainNewsController : BaseController<MainNews ,int,MainNewsListViewModel, MainNewsEditModel,MainNewsSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IMainNewsService _mainNewsService;
        public MainNewsController(IMainNewsService mainNewsService, IMapper mapper) : base(mainNewsService, mapper)
        {
            _mapper=mapper;
            _mainNewsService=mainNewsService;
        }
                [HttpGet("GetByNewsStoreIdForList")]
        public async Task<LoadResult> GetByNewsStoreIdForList(CustomDataSourceLoadOptions loadOptions,int newsStoreId)
        {
            var mainNewss = _mainNewsService.GetByNewsStoreId(newsStoreId);
            return await DataSourceLoader.LoadAsync(mainNewss.ProjectTo<MainNewsListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByNewsPropertyIdForList")]
        public async Task<LoadResult> GetByNewsPropertyIdForList(CustomDataSourceLoadOptions loadOptions,int newsPropertyId)
        {
            var mainNewss = _mainNewsService.GetByNewsPropertyId(newsPropertyId);
            return await DataSourceLoader.LoadAsync(mainNewss.ProjectTo<MainNewsListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByCreateByForList")]
        public async Task<LoadResult> GetByCreateByForList(CustomDataSourceLoadOptions loadOptions,int createBy)
        {
            var mainNewss = _mainNewsService.GetByCreateBy(createBy);
            return await DataSourceLoader.LoadAsync(mainNewss.ProjectTo<MainNewsListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByModifyByForList")]
        public async Task<LoadResult> GetByModifyByForList(CustomDataSourceLoadOptions loadOptions,int modifyBy)
        {
            var mainNewss = _mainNewsService.GetByModifyBy(modifyBy);
            return await DataSourceLoader.LoadAsync(mainNewss.ProjectTo<MainNewsListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByApplicationIdForList")]
        public async Task<LoadResult> GetByApplicationIdForList(CustomDataSourceLoadOptions loadOptions,int applicationId)
        {
            var mainNewss = _mainNewsService.GetByApplicationId(applicationId);
            return await DataSourceLoader.LoadAsync(mainNewss.ProjectTo<MainNewsListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByCreatorOrganizationIdForList")]
        public async Task<LoadResult> GetByCreatorOrganizationIdForList(CustomDataSourceLoadOptions loadOptions,int creatorOrganizationId)
        {
            var mainNewss = _mainNewsService.GetByCreatorOrganizationId(creatorOrganizationId);
            return await DataSourceLoader.LoadAsync(mainNewss.ProjectTo<MainNewsListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
             




        
    }
}      