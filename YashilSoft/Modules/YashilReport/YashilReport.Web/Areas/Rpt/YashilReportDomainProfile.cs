using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;
using AutoMapper;
using Yashil.Core.CustomViewModels;
using YashilReport.Web.Areas.Rpt.ViewModels;
using static System.String;

namespace YashilReport.Web.Areas.Rpt
{
    public class YashilReportProfile : Profile, IOrderedMapperProfile
    {
        public int Order => 1;

        public YashilReportProfile()
        {
            CreateMap<ReportGroup, ReportGroupEditModel>();

            CreateMap<ReportGroup, ReportGroupListViewModel>();

            CreateMap<ReportGroup, ReportGroupViewModel>();

            CreateMap<ReportGroupEditModel, ReportGroup>();

            CreateMap<ReportGroup, ReportGroupSimpleViewModel>();


            CreateMap<ReportConnectionString, ReportConnectionStringEditModel>()
                .ForMember(x => x.ReportTitle,
                    b => b.MapFrom(c => c.Report.Title))
                .ForMember(x => x.ConnectionStringTitle,
                    b => b.MapFrom(c => c.ConnectionString.Title));

            CreateMap<ReportConnectionString, ReportConnectionStringListViewModel>()
                .ForMember(x => x.ReportTitle,
                    b => b.MapFrom(c => c.Report.Title)).ForMember(x => x.ConnectionStringTitle,
                    b => b.MapFrom(c => c.ConnectionString.Title));

            CreateMap<ReportConnectionString, ReportConnectionStringViewModel>()
                .ForMember(x => x.ReportTitle,
                    b => b.MapFrom(c => c.Report.Title)).ForMember(x => x.ConnectionStringTitle,
                    b => b.MapFrom(c => c.ConnectionString.Title));

            CreateMap<ReportConnectionStringEditModel, ReportConnectionString>();

            CreateMap<ReportConnectionString, ReportConnectionStringSimpleViewModel>();


            CreateMap<ReportStore, ReportStoreEditModel>()
                .ForMember(x => x.AccessLevelTitle, b => b.MapFrom(c => c.AccessLevel.Title))
                .ForMember(x => x.ConnectionStringIds,
                    b => b.MapFrom(c => c.ReportConnectionString.Select(d => d.ConnectionStringId)));

            CreateMap<ReportStore, ReportStoreListViewModel>()
                .ForMember(x => x.AccessLevelTitle,
                    b => b.MapFrom(c => c.AccessLevel.Title));
            CreateMap<ReportStore, StoreCustomViewModel>()
                .ForMember(x => x.Groups, b => b.MapFrom(c => c.ReportGroupReport.Select(g => g.Id)));
            CreateMap<ReportStore, ReportStoreViewModel>()
                .ForMember(x => x.AccessLevelTitle, b => b.MapFrom(c => c.AccessLevel.Title));

            CreateMap<ReportStoreEditModel, ReportStore>();

            CreateMap<ReportStore, ReportStoreSimpleViewModel>();


            CreateMap<RoleReport, RoleReportEditModel>()
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title))
                .ForMember(x => x.ReportTitle,
                    b => b.MapFrom(c => c.Report.Title))
                ;

            CreateMap<RoleReport, RoleReportListViewModel>()
                .ForMember(x => x.RoleTitle,
                    b => b.MapFrom(c => c.Role.Title)).ForMember(x => x.ReportTitle,
                    b => b.MapFrom(c => c.Report.Title));

            CreateMap<RoleReport, RoleReportViewModel>()
                .ForMember(x => x.RoleTitle, b => b.MapFrom(c => c.Role.Title))
                .ForMember(x => x.ReportTitle, b => b.MapFrom(c => c.Report.Title));

            CreateMap<RoleReportEditModel, RoleReport>();

            CreateMap<RoleReport, RoleReportSimpleViewModel>();


            CreateMap<UserReport, UserReportEditModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName))
                .ForMember(x => x.ReportTitle,
                    b => b.MapFrom(c => c.Report.Title))
                ;

            CreateMap<UserReport, UserReportListViewModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName))
                .ForMember(x => x.ReportTitle,
                    b => b.MapFrom(c => c.Report.Title));

            CreateMap<UserReport, UserReportViewModel>()
                .ForMember(x => x.UserTitle,
                    b => b.MapFrom(c => c.User.UserName))
                .ForMember(x => x.ReportTitle,
                    b => b.MapFrom(c => c.Report.Title));

            CreateMap<UserReportEditModel, UserReport>();

            CreateMap<UserReport, UserReportSimpleViewModel>();


            CreateMap<ReportGroupReport, ReportGroupReportEditModel>()
                .ForMember(x => x.ReportStoreTitle,
                    b => b.MapFrom(c => c.ReportStore.Title))
                .ForMember(x => x.ReportGroupTitle,
                    b => b.MapFrom(c => c.ReportGroup.Title));

            CreateMap<ReportGroupReport, ReportGroupReportListViewModel>()
                .ForMember(x => x.ReportStoreTitle,
                    b => b.MapFrom(c => c.ReportStore.Title))
                .ForMember(x => x.ReportGroupTitle,
                    b => b.MapFrom(c => c.ReportGroup.Title));

            CreateMap<ReportGroupReport, ReportGroupReportViewModel>()
                .ForMember(x => x.ReportStoreTitle,
                    b => b.MapFrom(c => c.ReportStore.Title))
                .ForMember(x => x.ReportGroupTitle,
                    b => b.MapFrom(c => c.ReportGroup.Title));

            CreateMap<ReportGroupReportEditModel, ReportGroupReport>();

            CreateMap<ReportGroupReport, ReportGroupReportSimpleViewModel>();
        }
    }
}