	 
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
              [HttpGet("GetByCustomFilterForList")]
        public async Task<LoadResult> GetByCustomFilterForList(CustomDataSourceLoadOptions loadOptions,  int? newsStoreId)
        {
            var mainNewss = _mainNewsService.GetByCustomFilter(newsStoreId);
            return await DataSourceLoader.LoadAsync(mainNewss.ProjectTo<MainNewsListViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
        [HttpGet("GetByCustomForSelect")]
        public async Task<LoadResult> GetByCustomForSelect(CustomDataSourceLoadOptions loadOptions,  int? newsStoreId)
        {
            var mainNewss = _mainNewsService.GetByCustomFilter(newsStoreId);
            return await DataSourceLoader.LoadAsync(mainNewss.ProjectTo<MainNewsSimpleViewModel>(_mapper.ConfigurationProvider), loadOptions);
        }
  
    }
}      