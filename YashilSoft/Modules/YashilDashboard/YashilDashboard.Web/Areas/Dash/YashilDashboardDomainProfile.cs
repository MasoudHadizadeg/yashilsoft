using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;
using AutoMapper;
using Yashil.Core.Entities;
using YashilDashboard.Web.Areas.Dash.ViewModels;

namespace YashilDashboard.Web.Areas.Dash
{
    public class YashilDashboardProfile : Profile, IOrderedMapperProfile
    {
        public int Order => 1;

        public YashilDashboardProfile()
        {
            CreateMap<DashboardStore, DashboardStoreEditModel>()
                .ForMember(x => x.AccessLevelTitle, b => b.MapFrom(c => c.AccessLevel.Title))
                .ForMember(x => x.ConnectionStringIds,
                    b => b.MapFrom(c =>
                        c.DashboardConnectionString.Select(x =>  x.ConnectionString.Id)));

            CreateMap<DashboardStore, DashboardStoreListViewModel>()
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));

            CreateMap<DashboardStore, DashboardStoreViewModel>()
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));

            CreateMap<DashboardStoreEditModel, DashboardStore>();

            CreateMap<DashboardStore, DashboardStoreSimpleViewModel>();


            CreateMap<DashboardConnectionString, DashboardConnectionStringEditModel>()
                .ForMember(x => x.DashboardTitle,
                    b => b.MapFrom(c => c.Dashboard.Title))
                .ForMember(x => x.ConnectionStringTitle,
                    b => b.MapFrom(c => c.ConnectionString.Title))
                ;

            CreateMap<DashboardConnectionString, DashboardConnectionStringListViewModel>()
                .ForMember(x => x.DashboardTitle,
                    b => b.MapFrom(c => c.Dashboard.Title)).ForMember(x => x.ConnectionStringTitle,
                    b => b.MapFrom(c => c.ConnectionString.Title));

            CreateMap<DashboardConnectionString, DashboardConnectionStringViewModel>()
                .ForMember(x => x.DashboardTitle,
                    b => b.MapFrom(c => c.Dashboard.Title)).ForMember(x => x.ConnectionStringTitle,
                    b => b.MapFrom(c => c.ConnectionString.Title));

            CreateMap<DashboardConnectionStringEditModel, DashboardConnectionString>();

            CreateMap<DashboardConnectionString, DashboardConnectionStringSimpleViewModel>();


            CreateMap<UserDashboard, UserDashboardEditModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName))
                .ForMember(x => x.DashboardTitle,
                    b => b.MapFrom(c => c.Dashboard.Title))
                ;

            CreateMap<UserDashboard, UserDashboardListViewModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName)).ForMember(x => x.DashboardTitle,
                    b => b.MapFrom(c => c.Dashboard.Title));

            CreateMap<UserDashboard, UserDashboardViewModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName)).ForMember(x => x.DashboardTitle,
                    b => b.MapFrom(c => c.Dashboard.Title));

            CreateMap<UserDashboardEditModel, UserDashboard>();

            CreateMap<UserDashboard, UserDashboardSimpleViewModel>();


            CreateMap<RoleDashboard, RoleDashboardEditModel>()
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title))
                .ForMember(x => x.DashboardTitle,
                    b => b.MapFrom(c => c.Dashboard.Title))
                ;

            CreateMap<RoleDashboard, RoleDashboardListViewModel>()
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title)).ForMember(x => x.DashboardTitle,
                    b => b.MapFrom(c => c.Dashboard.Title));

            CreateMap<RoleDashboard, RoleDashboardViewModel>()
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title)).ForMember(x => x.DashboardTitle,
                    b => b.MapFrom(c => c.Dashboard.Title));

            CreateMap<RoleDashboardEditModel, RoleDashboard>();

            CreateMap<RoleDashboard, RoleDashboardSimpleViewModel>();


            CreateMap<DashboardGroup, DashboardGroupEditModel>()
                ;

            CreateMap<DashboardGroup, DashboardGroupListViewModel>()
                ;

            CreateMap<DashboardGroup, DashboardGroupViewModel>()
                ;

            CreateMap<DashboardGroupEditModel, DashboardGroup>();

            CreateMap<DashboardGroup, DashboardGroupSimpleViewModel>();


            CreateMap<DashboardGroupDashboard, DashboardGroupDashboardEditModel>()
                .ForMember(x => x.DashboardStoreTitle,
                    b => b.MapFrom(c => c.DashboardStore.Title))
                .ForMember(x => x.DashboardGroupTitle,
                    b => b.MapFrom(c => c.DashboardGroup.Title))
                ;

            CreateMap<DashboardGroupDashboard, DashboardGroupDashboardListViewModel>()
                .ForMember(x => x.DashboardStoreTitle,
                    b => b.MapFrom(c => c.DashboardStore.Title)).ForMember(x => x.DashboardGroupTitle,
                    b => b.MapFrom(c => c.DashboardGroup.Title));

            CreateMap<DashboardGroupDashboard, DashboardGroupDashboardViewModel>()
                .ForMember(x => x.DashboardStoreTitle,
                    b => b.MapFrom(c => c.DashboardStore.Title)).ForMember(x => x.DashboardGroupTitle,
                    b => b.MapFrom(c => c.DashboardGroup.Title));

            CreateMap<DashboardGroupDashboardEditModel, DashboardGroupDashboard>();

            CreateMap<DashboardGroupDashboard, DashboardGroupDashboardSimpleViewModel>();
        }
    }
}