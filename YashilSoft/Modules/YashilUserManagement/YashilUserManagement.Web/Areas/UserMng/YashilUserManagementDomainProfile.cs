using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;
using AutoMapper;
using YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng
{
    public class YashilUserManagementProfile : Profile, IOrderedMapperProfile
    {
        public int Order => 1;

        public YashilUserManagementProfile()
        {
            CreateMap<Resource, ResourceEditModel>()
                ;

            CreateMap<Resource, ResourceListViewModel>()
                ;

            CreateMap<Resource, ResourceViewModel>()
                ;

            CreateMap<ResourceEditModel, Resource>();

            CreateMap<Resource, ResourceSimpleViewModel>();


            CreateMap<Application, ApplicationEditModel>()
                ;

            CreateMap<Application, ApplicationListViewModel>()
                ;

            CreateMap<Application, ApplicationViewModel>()
                ;

            CreateMap<ApplicationEditModel, Application>();

            CreateMap<Application, ApplicationSimpleViewModel>();


            CreateMap<Organization, OrganizationEditModel>()
                ;

            CreateMap<Organization, OrganizationListViewModel>()
                ;

            CreateMap<Organization, OrganizationViewModel>()
                ;

            CreateMap<OrganizationEditModel, Organization>();

            CreateMap<Organization, OrganizationSimpleViewModel>();


            CreateMap<AppAction, AppActionEditModel>()
                ;

            CreateMap<AppAction, AppActionListViewModel>()
                ;

            CreateMap<AppAction, AppActionViewModel>()
                ;

            CreateMap<AppActionEditModel, AppAction>();

            CreateMap<AppAction, AppActionSimpleViewModel>();


            CreateMap<ResourceAppAction, ResourceAppActionEditModel>()
                .ForMember(x => x.AppActionTitle,
                    b => b.MapFrom(c => c.AppAction.Title))
                .ForMember(x => x.ResourceTitle,
                    b => b.MapFrom(c => c.Resource.Title))
                ;

            CreateMap<ResourceAppAction, ResourceAppActionListViewModel>()
                .ForMember(x => x.AppActionTitle,
                    b => b.MapFrom(c => c.AppAction.Title)).ForMember(x => x.ResourceTitle,
                    b => b.MapFrom(c => c.Resource.Title));

            CreateMap<ResourceAppAction, ResourceAppActionViewModel>()
                .ForMember(x => x.AppActionTitle,
                    b => b.MapFrom(c => c.AppAction.Title)).ForMember(x => x.ResourceTitle,
                    b => b.MapFrom(c => c.Resource.Title));

            CreateMap<ResourceAppActionEditModel, ResourceAppAction>();

            CreateMap<ResourceAppAction, ResourceAppActionSimpleViewModel>();


            CreateMap<RoleResourceAction, RoleResourceActionEditModel>()
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title))
                ;

            CreateMap<RoleResourceAction, RoleResourceActionListViewModel>()
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title));

            CreateMap<RoleResourceAction, RoleResourceActionViewModel>()
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title));

            CreateMap<RoleResourceActionEditModel, RoleResourceAction>();

            CreateMap<RoleResourceAction, RoleResourceActionSimpleViewModel>();


            CreateMap<AppConfig, AppConfigEditModel>()
                ;

            CreateMap<AppConfig, AppConfigListViewModel>()
                ;

            CreateMap<AppConfig, AppConfigViewModel>()
                ;

            CreateMap<AppConfigEditModel, AppConfig>();

            CreateMap<AppConfig, AppConfigSimpleViewModel>();


            CreateMap<User, UserEditModel>();

            CreateMap<User, UserListViewModel>()
                .ForMember(x => x.OrganizationTitle,
                    b => b.MapFrom(c => c.Organization.Title))
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));

            CreateMap<User, UserViewModel>()
                .ForMember(x => x.OrganizationTitle,
                    b => b.MapFrom(c => c.Organization.Title)).ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));

            CreateMap<UserEditModel, User>();

            CreateMap<User, UserSimpleViewModel>().ForMember(x => x.Title,
                b => b.MapFrom(c => c.FirstName + " " + c.LastName));


            CreateMap<Role, RoleEditModel>();

            CreateMap<Role, RoleListViewModel>();

            CreateMap<Role, RoleViewModel>();

            CreateMap<RoleEditModel, Role>();

            CreateMap<Role, RoleSimpleViewModel>();


            CreateMap<Menu, MenuEditModel>()
                .ForMember(x => x.ResourceTitle,
                    b => b.MapFrom(c => c.Resource.Title));

            CreateMap<Menu, MenuListViewModel>()
                .ForMember(x => x.ResourceTitle,
                    b => b.MapFrom(c => c.Resource.Title));

            CreateMap<Menu, MenuViewModel>()
                .ForMember(x => x.ResourceTitle,
                    b => b.MapFrom(c => c.Resource.Title));

            CreateMap<MenuEditModel, Menu>();

            CreateMap<Menu, MenuSimpleViewModel>();


            CreateMap<UserRole, UserRoleEditModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName))
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title))
                ;

            CreateMap<UserRole, UserRoleListViewModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName)).ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title));

            CreateMap<UserRole, UserRoleViewModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName)).ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title));

            CreateMap<UserRoleEditModel, UserRole>();

            CreateMap<UserRole, UserRoleSimpleViewModel>();
        }
    }
}