

	 

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
	public class NewsKeywordController : BaseController<NewsKeyword ,int,NewsKeywordListViewModel, NewsKeywordEditModel,NewsKeywordSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly INewsKeywordService _newsKeywordService;
        public NewsKeywordController(INewsKeywordService newsKeywordService, IMapper mapper) : base(newsKeywordService, mapper)
        {
            _mapper=mapper;
            _newsKeywordService=newsKeywordService;
        }
                [HttpGet("GetByNewsStoreIdForList")]
        public async Task<LoadResult> GetByNewsStoreIdForList(CustomDataSourceLoadOptions loadOptions,int newsStoreId)
        {
            var newsKeywords = _newsKeywordService.GetByNewsStoreId(newsStoreId);
            return await DataSourceLoader.LoadAsync(newsKeywords.ProjectTo<NewsKeywordListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByKeywordIdForList")]
        public async Task<LoadResult> GetByKeywordIdForList(CustomDataSourceLoadOptions loadOptions,int keywordId)
        {
            var newsKeywords = _newsKeywordService.GetByKeywordId(keywordId);
            return await DataSourceLoader.LoadAsync(newsKeywords.ProjectTo<NewsKeywordListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByCreateByForList")]
        public async Task<LoadResult> GetByCreateByForList(CustomDataSourceLoadOptions loadOptions,int createBy)
        {
            var newsKeywords = _newsKeywordService.GetByCreateBy(createBy);
            return await DataSourceLoader.LoadAsync(newsKeywords.ProjectTo<NewsKeywordListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByModifyByForList")]
        public async Task<LoadResult> GetByModifyByForList(CustomDataSourceLoadOptions loadOptions,int modifyBy)
        {
            var newsKeywords = _newsKeywordService.GetByModifyBy(modifyBy);
            return await DataSourceLoader.LoadAsync(newsKeywords.ProjectTo<NewsKeywordListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByApplicationIdForList")]
        public async Task<LoadResult> GetByApplicationIdForList(CustomDataSourceLoadOptions loadOptions,int applicationId)
        {
            var newsKeywords = _newsKeywordService.GetByApplicationId(applicationId);
            return await DataSourceLoader.LoadAsync(newsKeywords.ProjectTo<NewsKeywordListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByAccessLevelIdForList")]
        public async Task<LoadResult> GetByAccessLevelIdForList(CustomDataSourceLoadOptions loadOptions,int accessLevelId)
        {
            var newsKeywords = _newsKeywordService.GetByAccessLevelId(accessLevelId);
            return await DataSourceLoader.LoadAsync(newsKeywords.ProjectTo<NewsKeywordListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
              [HttpGet("GetByCreatorOrganizationIdForList")]
        public async Task<LoadResult> GetByCreatorOrganizationIdForList(CustomDataSourceLoadOptions loadOptions,int creatorOrganizationId)
        {
            var newsKeywords = _newsKeywordService.GetByCreatorOrganizationId(creatorOrganizationId);
            return await DataSourceLoader.LoadAsync(newsKeywords.ProjectTo<NewsKeywordListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        
             




        
    }
}      