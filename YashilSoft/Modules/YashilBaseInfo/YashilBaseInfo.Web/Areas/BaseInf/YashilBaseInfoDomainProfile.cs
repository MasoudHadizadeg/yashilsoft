
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;
using AutoMapper;
using YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf
{

	public class YashilBaseInfoProfile : Profile,IOrderedMapperProfile
		{
             public int Order => 1;
			 public YashilBaseInfoProfile()
				{	
					
				CreateMap<YashilDataProvider, YashilDataProviderEditModel>()
				;

                CreateMap<YashilDataProvider, YashilDataProviderListViewModel>()
						;

				CreateMap<YashilDataProvider, YashilDataProviderViewModel>()
						;

				CreateMap<YashilDataProviderEditModel, YashilDataProvider>();

                CreateMap<YashilDataProvider, YashilDataProviderSimpleViewModel>();
	   
					
				CreateMap<YashilConnectionString, YashilConnectionStringEditModel>()
									.ForMember(x => x.DataProviderTitle, 
					b => b.MapFrom(c => c.DataProvider.Title))
				;

                CreateMap<YashilConnectionString, YashilConnectionStringListViewModel>()
											.ForMember(x => x.DataProviderTitle, 
					b => b.MapFrom(c => c.DataProvider.Title));

				CreateMap<YashilConnectionString, YashilConnectionStringViewModel>()
											.ForMember(x => x.DataProviderTitle, 
					b => b.MapFrom(c => c.DataProvider.Title));

				CreateMap<YashilConnectionStringEditModel, YashilConnectionString>();

                CreateMap<YashilConnectionString, YashilConnectionStringSimpleViewModel>();
	   
					
				CreateMap<AccessLevel, AccessLevelEditModel>()
				;

                CreateMap<AccessLevel, AccessLevelListViewModel>()
						;

				CreateMap<AccessLevel, AccessLevelViewModel>()
						;

				CreateMap<AccessLevelEditModel, AccessLevel>();

                CreateMap<AccessLevel, AccessLevelSimpleViewModel>();
	   
			}
	}
}
