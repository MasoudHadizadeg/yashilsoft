	 
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
	public class NewsStoreController : BaseController<NewsStore ,int,NewsStoreListViewModel, NewsStoreEditModel,NewsStoreSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly INewsStoreService _newsStoreService;
        public NewsStoreController(INewsStoreService newsStoreService, IMapper mapper) : base(newsStoreService, mapper)
        {
            _mapper=mapper;
            _newsStoreService=newsStoreService;
        }
              [HttpGet("GetByCustomFilterForList")]
        public async Task<LoadResult> GetByCustomFilterForList(CustomDataSourceLoadOptions loadOptions,  int? serviceId, int? newsType, int? language)
        {
            var newsStores = _newsStoreService.GetByCustomFilter(serviceId,newsType,language);
            return await DataSourceLoader.LoadAsync(newsStores.ProjectTo<NewsStoreListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCustomForSelect")]
        public async Task<LoadResult> GetByCustomForSelect(CustomDataSourceLoadOptions loadOptions,  int? serviceId, int? newsType, int? language)
        {
            var newsStores = _newsStoreService.GetByCustomFilter(serviceId,newsType,language);
            return await DataSourceLoader.LoadAsync(newsStores.ProjectTo<NewsStoreSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
  
    }
}      