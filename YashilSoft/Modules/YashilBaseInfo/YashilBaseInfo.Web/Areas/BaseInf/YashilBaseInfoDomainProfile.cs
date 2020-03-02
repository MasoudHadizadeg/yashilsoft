using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;
using AutoMapper;
using YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf
{
    public class YashilBaseInfoProfile : Profile, IOrderedMapperProfile
    {
        public int Order => 1;

        public YashilBaseInfoProfile()
        {
            CreateMap<City, CityEditModel>()
            .ForMember(x => x.CustomCategoryTitle, b => b.MapFrom(c => c.CustomCategoryNavigation.Title)).ForMember(x => x.CountryDivisionTypeTitle, b => b.MapFrom(c => c.CountryDivisionTypeNavigation.Title));


            CreateMap<City, CityListViewModel>()
            .ForMember(x => x.CustomCategoryTitle, b => b.MapFrom(c => c.CustomCategoryNavigation.Title)).ForMember(x => x.CountryDivisionTypeTitle, b => b.MapFrom(c => c.CountryDivisionTypeNavigation.Title));
            CreateMap<CityEditModel, City>();

            CreateMap<City, CitySimpleViewModel>();


            CreateMap<AppEntity, AppEntityEditModel>()
            ;


            CreateMap<AppEntity, AppEntityListViewModel>()
            ;
            CreateMap<AppEntityEditModel, AppEntity>();

            CreateMap<AppEntity, AppEntitySimpleViewModel>();


            CreateMap<CommonBaseData, CommonBaseDataEditModel>()
                                .ForMember(x => x.CommonBaseTypeTitle,
                b => b.MapFrom(c => c.CommonBaseType.Title))
                            .ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;


            CreateMap<CommonBaseData, CommonBaseDataListViewModel>()
                                .ForMember(x => x.CommonBaseTypeTitle,
                b => b.MapFrom(c => c.CommonBaseType.Title))
                            .ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;
            CreateMap<CommonBaseDataEditModel, CommonBaseData>();

            CreateMap<CommonBaseData, CommonBaseDataSimpleViewModel>();


            CreateMap<AccessLevel, AccessLevelEditModel>()
            ;


            CreateMap<AccessLevel, AccessLevelListViewModel>()
            ;
            CreateMap<AccessLevelEditModel, AccessLevel>();

            CreateMap<AccessLevel, AccessLevelSimpleViewModel>();


            CreateMap<YashilDataProvider, YashilDataProviderEditModel>()
            ;


            CreateMap<YashilDataProvider, YashilDataProviderListViewModel>()
            ;
            CreateMap<YashilDataProviderEditModel, YashilDataProvider>();

            CreateMap<YashilDataProvider, YashilDataProviderSimpleViewModel>();


            CreateMap<CommonBaseType, CommonBaseTypeEditModel>()
                                .ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;


            CreateMap<CommonBaseType, CommonBaseTypeListViewModel>()
                                .ForMember(x => x.AccessLevelTitle,
                b => b.MapFrom(c => c.AccessLevel.Title))
        ;
            CreateMap<CommonBaseTypeEditModel, CommonBaseType>();

            CreateMap<CommonBaseType, CommonBaseTypeSimpleViewModel>();


            CreateMap<YashilConnectionString, YashilConnectionStringEditModel>()
                                .ForMember(x => x.DataProviderTitle,
                b => b.MapFrom(c => c.DataProvider.Title))
        ;


            CreateMap<YashilConnectionString, YashilConnectionStringListViewModel>()
                                .ForMember(x => x.DataProviderTitle, b => b.MapFrom(c => c.DataProvider.Title));
            CreateMap<YashilConnectionStringEditModel, YashilConnectionString>();

            CreateMap<YashilConnectionString, YashilConnectionStringSimpleViewModel>();
        }
    }
}