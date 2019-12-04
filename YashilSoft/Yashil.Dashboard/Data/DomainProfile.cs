using AutoMapper;
using Yashil.Dashboard.Web.ViewModels;

namespace Yashil.Dashboard.Web.Data
{
  public class DomainProfile : Profile
  {
    //public DomainProfile()
    //{
    //  CreateMap<Resource, ResourceEditModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title))
    //    ;


    //  CreateMap<Resource, ResourceViewModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title));

    //  CreateMap<ResourceEditModel, Resource>();


    //  CreateMap<User, UserEditModel>()
    //    .ForMember(x => x.OrganizationTitle,
    //      b => b.MapFrom(c => c.Organization.Title))
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title))
    //    .ForMember(x => x.AccessLevelTitle,
    //      b => b.MapFrom(c => c.AccessLevelNavigation.Title))
    //    ;


    //  CreateMap<User, UserViewModel>()
    //    .ForMember(x => x.OrganizationTitle,
    //      b => b.MapFrom(c => c.Organization.Title)).ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title)).ForMember(x => x.AccessLevelTitle,
    //      b => b.MapFrom(c => c.AccessLevelNavigation.Title));

    //  CreateMap<UserEditModel, User>();


    //  CreateMap<Organization, OrganizationEditModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title))
    //    ;


    //  CreateMap<Organization, OrganizationViewModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title));

    //  CreateMap<OrganizationEditModel, Organization>();


    //  CreateMap<AppConfig, AppConfigEditModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title))
    //    ;


    //  CreateMap<AppConfig, AppConfigViewModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title));

    //  CreateMap<AppConfigEditModel, AppConfig>();


    //  CreateMap<AppAction, AppActionEditModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title))
    //    ;


    //  CreateMap<AppAction, AppActionViewModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title));

    //  CreateMap<AppActionEditModel, AppAction>();


    //  CreateMap<ResourceAppAction, ResourceAppActionEditModel>()
    //    .ForMember(x => x.AppActionTitle,
    //      b => b.MapFrom(c => c.AppAction.Title))
    //    .ForMember(x => x.ResourceTitle,
    //      b => b.MapFrom(c => c.Resource.Title))
    //    ;


    //  CreateMap<ResourceAppAction, ResourceAppActionViewModel>()
    //    .ForMember(x => x.AppActionTitle,
    //      b => b.MapFrom(c => c.AppAction.Title)).ForMember(x => x.ResourceTitle,
    //      b => b.MapFrom(c => c.Resource.Title));

    //  CreateMap<ResourceAppActionEditModel, ResourceAppAction>();


    //  CreateMap<RoleResourceAction, RoleResourceActionEditModel>()
    //    .ForMember(x => x.ResourceActionTitle,
    //      b => b.MapFrom(c => c.ResourceAction.Resource.Title + ' ' + c.ResourceAction.AppAction.Title))
    //    .ForMember(x => x.RoleTitle,
    //      b => b.MapFrom(c => c.Role.Title))
    //    ;


    //  CreateMap<RoleResourceAction, RoleResourceActionViewModel>()
    //    .ForMember(x => x.ResourceActionTitle,
    //      b => b.MapFrom(c => c.ResourceAction.Resource.Title + ' ' + c.ResourceAction.AppAction.Title)).ForMember(
    //      x => x.RoleTitle,
    //      b => b.MapFrom(c => c.Role.Title));

    //  CreateMap<RoleResourceActionEditModel, RoleResourceAction>();


    //  CreateMap<Menu, MenuEditModel>()
    //    .ForMember(x => x.ResourceTitle,
    //      b => b.MapFrom(c => c.Resource.Title))
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title))
    //    ;


    //  CreateMap<Menu, MenuViewModel>()
    //    .ForMember(x => x.ResourceTitle,
    //      b => b.MapFrom(c => c.Resource.Title)).ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title));

    //  CreateMap<MenuEditModel, Menu>();


    //  CreateMap<Application, ApplicationEditModel>()
    //    ;


    //  CreateMap<Application, ApplicationViewModel>()
    //    ;

    //  CreateMap<ApplicationEditModel, Application>();


    //  CreateMap<UserDashboard, UserDashboardEditModel>()
    //    .ForMember(x => x.DashboardTitle,
    //      b => b.MapFrom(c => c.Dashboard.Title));


    //  CreateMap<UserDashboard, UserDashboardViewModel>()
    //    .ForMember(x => x.DashboardTitle,
    //      b => b.MapFrom(c => c.Dashboard.Title));

    //  CreateMap<UserDashboardEditModel, UserDashboard>();


    //  CreateMap<RoleDashboard, RoleDashboardEditModel>()
    //    .ForMember(x => x.RoleTitle,
    //      b => b.MapFrom(c => c.Role.Title))
    //    .ForMember(x => x.DashboardTitle,
    //      b => b.MapFrom(c => c.Dashboard.Title))
    //    ;


    //  CreateMap<RoleDashboard, RoleDashboardViewModel>()
    //    .ForMember(x => x.RoleTitle,
    //      b => b.MapFrom(c => c.Role.Title)).ForMember(x => x.DashboardTitle,
    //      b => b.MapFrom(c => c.Dashboard.Title));

    //  CreateMap<RoleDashboardEditModel, RoleDashboard>();


    //  CreateMap<Dashboard, DashboardEditModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title))
    //    .ForMember(x => x.AccessLevelTitle,
    //      b => b.MapFrom(c => c.AccessLevelNavigation.Title))
    //    ;


    //  CreateMap<Dashboard, DashboardViewModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title)).ForMember(x => x.AccessLevelTitle,
    //      b => b.MapFrom(c => c.AccessLevelNavigation.Title));

    //  CreateMap<DashboardEditModel, Dashboard>();


    //  CreateMap<AccessLevel, AccessLevelEditModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title))
    //    ;


    //  CreateMap<AccessLevel, AccessLevelViewModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title));

    //  CreateMap<AccessLevelEditModel, AccessLevel>();


    //  CreateMap<Role, RoleEditModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title))
    //    ;


    //  CreateMap<Role, RoleViewModel>()
    //    .ForMember(x => x.ApplicationTitle,
    //      b => b.MapFrom(c => c.Application.Title));

    //  CreateMap<RoleEditModel, Role>();


    //  CreateMap<UserRole, UserRoleEditModel>()
    //    .ForMember(x => x.UserTitle,
    //      b => b.MapFrom(c => c.User.UserName))
    //    .ForMember(x => x.RoleTitle,
    //      b => b.MapFrom(c => c.Role.Title))
    //    ;


    //  CreateMap<UserRole, UserRoleViewModel>()
    //    .ForMember(x => x.UserTitle,
    //      b => b.MapFrom(c => c.User.UserName)).ForMember(x => x.RoleTitle,
    //      b => b.MapFrom(c => c.Role.Title));

    //  CreateMap<UserRoleEditModel, UserRole>();
    //}
  }
}
