
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;
using AutoMapper; 
using Yashil.Core.Entities;
using YashilNews.Web.Areas.News.ViewModels;

namespace YashilNews.Web.Areas.News
{

	public class YashilNewsProfile : Profile,IOrderedMapperProfile
		{
             public int Order => 1;
			 public YashilNewsProfile()
				{	
					
				CreateMap<MainNews, MainNewsEditModel>();

                CreateMap<MainNews, MainNewsListViewModel>()
									.ForMember(x => x.NewsStoreTitle, 
					b => b.MapFrom(c => c.NewsStore.Title))
			;			
				CreateMap<MainNewsEditModel, MainNews>();

                CreateMap<MainNews, MainNewsSimpleViewModel>();
	   
					
				CreateMap<Service, ServiceEditModel>();

                CreateMap<Service, ServiceListViewModel>()
									.ForMember(x => x.AppEntityTitle, 
					b => b.MapFrom(c => c.AppEntity.Title))
								.ForMember(x => x.AccessLevelTitle, 
					b => b.MapFrom(c => c.AccessLevel.Title))
			;			
				CreateMap<ServiceEditModel, Service>();

                CreateMap<Service, ServiceSimpleViewModel>();
	   
					
				CreateMap<NewsStore, NewsStoreEditModel>();

                CreateMap<NewsStore, NewsStoreListViewModel>()
									.ForMember(x => x.ServiceTitle, 
					b => b.MapFrom(c => c.Service.Title))
			.ForMember(x => x.NewsTypeTitle, b => b.MapFrom(c => c.NewsTypeNavigation.Title)).ForMember(x => x.LanguageTitle, b => b.MapFrom(c => c.LanguageNavigation.Title))					.ForMember(x => x.AccessLevelTitle, 
					b => b.MapFrom(c => c.AccessLevel.Title))
			;			
				CreateMap<NewsStoreEditModel, NewsStore>();

                CreateMap<NewsStore, NewsStoreSimpleViewModel>();
	   
					
				CreateMap<NewsKeyword, NewsKeywordEditModel>();

                CreateMap<NewsKeyword, NewsKeywordListViewModel>()
									.ForMember(x => x.NewsStoreTitle, 
					b => b.MapFrom(c => c.NewsStore.Title))
								.ForMember(x => x.KeywordTitle, 
					b => b.MapFrom(c => c.Keyword.Title))
								.ForMember(x => x.AccessLevelTitle, 
					b => b.MapFrom(c => c.AccessLevel.Title))
			;			
				CreateMap<NewsKeywordEditModel, NewsKeyword>();

                CreateMap<NewsKeyword, NewsKeywordSimpleViewModel>();
	   
			}
	}
}
