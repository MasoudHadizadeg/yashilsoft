using System;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Core.Classes;
using AutoMapper;
using Yashil.Common.SharedKernel.Helpers;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilNews.Core.Services;
using YashilNews.Web.Areas.News.ViewModels;

namespace YashilNews.Web.Areas.News.Controllers
{
    public class NewsStoreController : BaseController<NewsStore, int, NewsStoreListViewModel, NewsStoreEditModel,
        NewsStoreSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly INewsStoreService _newsStoreService;

        public NewsStoreController(INewsStoreService newsStoreService, IMapper mapper) : base(newsStoreService, mapper)
        {
            _mapper = mapper;
            _newsStoreService = newsStoreService;
        }

        protected override void CustomMapAfterSelectById(NewsStoreEditModel model)
        {
            model.EffluenceDate=DateTime.Now;
            model.EffluenceDateInt = DateFunction.TodayShamsiInt();
            model.ExpireDate = DateTime.Now.AddYears(50);
            
            base.CustomMapAfterSelectById(model);
        }

        [HttpGet("GetByServiceIdForList")]
        public async Task<LoadResult> GetByServiceIdForList(CustomDataSourceLoadOptions loadOptions, int serviceId)
        {
            var newsStores = _newsStoreService.GetByServiceId(serviceId);
            return await DataSourceLoader.LoadAsync(
                newsStores.ProjectTo<NewsStoreListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        } 
        [HttpGet("GetByCustomFilter")]
        public async Task<LoadResult> GetByCustomFilter(CustomDataSourceLoadOptions loadOptions, int? serviceId,int? newsType,int? language)
        {
            var newsStores = _newsStoreService.GetByCustomFilter(serviceId, newsType, language);
            return await DataSourceLoader.LoadAsync(
                newsStores.ProjectTo<NewsStoreListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetByNewsTypeForList")]
        public async Task<LoadResult> GetByNewsTypeForList(CustomDataSourceLoadOptions loadOptions, int newsType)
        {
            var newsStores = _newsStoreService.GetByNewsType(newsType);
            return await DataSourceLoader.LoadAsync(
                newsStores.ProjectTo<NewsStoreListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetByLanguageForList")]
        public async Task<LoadResult> GetByLanguageForList(CustomDataSourceLoadOptions loadOptions, int language)
        {
            var newsStores = _newsStoreService.GetByLanguage(language);
            return await DataSourceLoader.LoadAsync(
                newsStores.ProjectTo<NewsStoreListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetByCreateByForList")]
        public async Task<LoadResult> GetByCreateByForList(CustomDataSourceLoadOptions loadOptions, int createBy)
        {
            var newsStores = _newsStoreService.GetByCreateBy(createBy);
            return await DataSourceLoader.LoadAsync(
                newsStores.ProjectTo<NewsStoreListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetByModifyByForList")]
        public async Task<LoadResult> GetByModifyByForList(CustomDataSourceLoadOptions loadOptions, int modifyBy)
        {
            var newsStores = _newsStoreService.GetByModifyBy(modifyBy);
            return await DataSourceLoader.LoadAsync(
                newsStores.ProjectTo<NewsStoreListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetByApplicationIdForList")]
        public async Task<LoadResult> GetByApplicationIdForList(CustomDataSourceLoadOptions loadOptions,
            int applicationId)
        {
            var newsStores = _newsStoreService.GetByApplicationId(applicationId);
            return await DataSourceLoader.LoadAsync(
                newsStores.ProjectTo<NewsStoreListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetByAccessLevelIdForList")]
        public async Task<LoadResult> GetByAccessLevelIdForList(CustomDataSourceLoadOptions loadOptions,
            int accessLevelId)
        {
            var newsStores = _newsStoreService.GetByAccessLevelId(accessLevelId);
            return await DataSourceLoader.LoadAsync(
                newsStores.ProjectTo<NewsStoreListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

        [HttpGet("GetByCreatorOrganizationIdForList")]
        public async Task<LoadResult> GetByCreatorOrganizationIdForList(CustomDataSourceLoadOptions loadOptions,
            int creatorOrganizationId)
        {
            var newsStores = _newsStoreService.GetByCreatorOrganizationId(creatorOrganizationId);
            return await DataSourceLoader.LoadAsync(
                newsStores.ProjectTo<NewsStoreListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
    }
}