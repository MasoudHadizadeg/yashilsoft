
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
using YashilNews.Web.Areas.News.ViewModels;

namespace YashilNews.Web.Areas.News.Controllers
{
    public class NewsKeywordController : BaseController<NewsKeyword, int, NewsKeywordListViewModel, NewsKeywordEditModel, NewsKeywordSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly INewsKeywordService _newsKeywordService;
        public NewsKeywordController(INewsKeywordService newsKeywordService, IMapper mapper) : base(newsKeywordService, mapper)
        {
            _mapper = mapper;
            _newsKeywordService = newsKeywordService;
        }
        [HttpGet("GetByCustomFilterForList")]
        public async Task<LoadResult> GetByCustomFilterForList(CustomDataSourceLoadOptions loadOptions, int? newsStoreId, int? keywordId)
        {
            var newsKeywords = _newsKeywordService.GetByCustomFilter(newsStoreId, keywordId);
            return await DataSourceLoader.LoadAsync(newsKeywords.ProjectTo<NewsKeywordListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCustomForSelect")]
        public async Task<LoadResult> GetByCustomForSelect(CustomDataSourceLoadOptions loadOptions, int? newsStoreId, int? keywordId)
        {
            var newsKeywords = _newsKeywordService.GetByCustomFilter(newsStoreId, keywordId);
            return await DataSourceLoader.LoadAsync(newsKeywords.ProjectTo<NewsKeywordSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }

    }
}