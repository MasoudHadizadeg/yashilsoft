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
            CreateMap<Resource, ResourceEditModel>();


            CreateMap<Resource, ResourceListViewModel>();
            CreateMap<ResourceEditModel, Resource>();

            CreateMap<Resource, ResourceSimpleViewModel>();


            CreateMap<Application, ApplicationEditModel>();


            CreateMap<Application, ApplicationListViewModel>()
                ;
            CreateMap<ApplicationEditModel, Application>();

            CreateMap<Application, ApplicationSimpleViewModel>();


            CreateMap<AppAction, AppActionEditModel>();


            CreateMap<AppAction, AppActionListViewModel>()
                ;
            CreateMap<AppActionEditModel, AppAction>();

            CreateMap<AppAction, AppActionSimpleViewModel>();


            CreateMap<Organization, OrganizationEditModel>()
                ;


            CreateMap<Organization, OrganizationListViewModel>()
                ;
            CreateMap<OrganizationEditModel, Organization>();

            CreateMap<Organization, OrganizationSimpleViewModel>();


            CreateMap<ResourceAppAction, ResourceAppActionEditModel>()
                .ForMember(x => x.AppActionTitle,
                    b => b.MapFrom(c => c.AppAction.Title))
                .ForMember(x => x.ResourceTitle,
                    b => b.MapFrom(c => c.Resource.Title))
                ;


            CreateMap<ResourceAppAction, ResourceAppActionListViewModel>()
                .ForMember(x => x.AppActionTitle,
                    b => b.MapFrom(c => c.AppAction.Title))
                .ForMember(x => x.ResourceTitle,
                    b => b.MapFrom(c => c.Resource.Title))
                ;
            CreateMap<ResourceAppActionEditModel, ResourceAppAction>();

            CreateMap<ResourceAppAction, ResourceAppActionSimpleViewModel>();


            CreateMap<RoleResourceAction, RoleResourceActionEditModel>()
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title))
                ;


            CreateMap<RoleResourceAction, RoleResourceActionListViewModel>()
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title))
                ;
            CreateMap<RoleResourceActionEditModel, RoleResourceAction>();

            CreateMap<RoleResourceAction, RoleResourceActionSimpleViewModel>();


            CreateMap<Role, RoleEditModel>()
                ;


            CreateMap<Role, RoleListViewModel>()
                ;
            CreateMap<RoleEditModel, Role>();

            CreateMap<Role, RoleSimpleViewModel>();


            CreateMap<AppConfig, AppConfigEditModel>()
                ;


            CreateMap<AppConfig, AppConfigListViewModel>()
                ;
            CreateMap<AppConfigEditModel, AppConfig>();

            CreateMap<AppConfig, AppConfigSimpleViewModel>();


            CreateMap<User, UserEditModel>()
                .ForMember(x => x.OrganizationTitle,
                    b => b.MapFrom(c => c.Organization.Title))
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));


            CreateMap<User, UserListViewModel>()
                .ForMember(x => x.OrganizationTitle,
                    b => b.MapFrom(c => c.Organization.Title))
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));
            CreateMap<UserEditModel, User>();

            CreateMap<User, UserSimpleViewModel>()
                .ForMember(x => x.Title, b => b.MapFrom(c => c.FirstName + " " + c.LastName));


            CreateMap<Menu, MenuEditModel>()
                .ForMember(x => x.ResourceTitle,
                    b => b.MapFrom(c => c.Resource.Title));


            CreateMap<Menu, MenuListViewModel>()
                .ForMember(x => x.ResourceTitle,
                    b => b.MapFrom(c => c.Resource.Title));
            CreateMap<MenuEditModel, Menu>();

            CreateMap<Menu, MenuSimpleViewModel>();


            CreateMap<UserRole, UserRoleEditModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName))
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title));


            CreateMap<UserRole, UserRoleListViewModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName))
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title));
            CreateMap<UserRoleEditModel, UserRole>();

            CreateMap<UserRole, UserRoleSimpleViewModel>().ForMember(x => x.Title, b => b.MapFrom(c => c.Role.Title));


            CreateMap<Post, PostEditModel>()
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));


            CreateMap<Post, PostListViewModel>()
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));
            CreateMap<PostEditModel, Post>();

            CreateMap<Post, PostSimpleViewModel>();


            CreateMap<Person, PersonEditModel>()
                .ForMember(x => x.GenderTitle, b => b.MapFrom(c => c.GenderNavigation.Title))
                .ForMember(x => x.EducationGradeTitle, b => b.MapFrom(c => c.EducationGradeNavigation.Title)).ForMember(
                    x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title))
                ;


            CreateMap<Person, PersonListViewModel>()
                .ForMember(x => x.GenderTitle, b => b.MapFrom(c => c.GenderNavigation.Title))
                .ForMember(x => x.EducationGradeTitle, b => b.MapFrom(c => c.EducationGradeNavigation.Title)).ForMember(
                    x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));
            CreateMap<PersonEditModel, Person>();

            CreateMap<Person, PersonSimpleViewModel>()
                .ForMember(x => x.Title, b => b.MapFrom(c => c.Name + " " + c.LastName));
        }
    }
}