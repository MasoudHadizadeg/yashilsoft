
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;
using AutoMapper; 
using Yashil.Core.Entities;
using YashilReport.Web.Areas.Rpt.ViewModels;

namespace YashilReport.Web.Areas.Rpt
{

	public class YashilReportProfile : Profile,IOrderedMapperProfile
		{
             public int Order => 1;
			 public YashilReportProfile()
				{	
					
				CreateMap<ReportConnectionString, ReportConnectionStringEditModel>()
									.ForMember(x => x.ReportTitle, 
					b => b.MapFrom(c => c.Report.Title))
									.ForMember(x => x.ConnectionStringTitle, 
					b => b.MapFrom(c => c.ConnectionString.Name))
				;

                CreateMap<ReportConnectionString, ReportConnectionStringListViewModel>()
											.ForMember(x => x.ReportTitle, 
					b => b.MapFrom(c => c.Report.Title))					.ForMember(x => x.ConnectionStringTitle, 
					b => b.MapFrom(c => c.ConnectionString.Name));

				CreateMap<ReportConnectionString, ReportConnectionStringViewModel>()
											.ForMember(x => x.ReportTitle, 
					b => b.MapFrom(c => c.Report.Title))					.ForMember(x => x.ConnectionStringTitle, 
					b => b.MapFrom(c => c.ConnectionString.Name));

				CreateMap<ReportConnectionStringEditModel, ReportConnectionString>();

                CreateMap<ReportConnectionString, ReportConnectionStringSimpleViewModel>();
	   
					
				CreateMap<RoleReport, RoleReportEditModel>()
									.ForMember(x => x.RoleTitle, 
					b => b.MapFrom(c => c.Role.Title))
									.ForMember(x => x.ReportTitle, 
					b => b.MapFrom(c => c.Report.Title))
				;

                CreateMap<RoleReport, RoleReportListViewModel>()
											.ForMember(x => x.RoleTitle, 
					b => b.MapFrom(c => c.Role.Title))					.ForMember(x => x.ReportTitle, 
					b => b.MapFrom(c => c.Report.Title));

				CreateMap<RoleReport, RoleReportViewModel>()
											.ForMember(x => x.RoleTitle, 
					b => b.MapFrom(c => c.Role.Title))					.ForMember(x => x.ReportTitle, 
					b => b.MapFrom(c => c.Report.Title));

				CreateMap<RoleReportEditModel, RoleReport>();

                CreateMap<RoleReport, RoleReportSimpleViewModel>();
	   
					
				CreateMap<ReportStore, ReportStoreEditModel>()
									.ForMember(x => x.AccessLevelTitle, 
					b => b.MapFrom(c => c.AccessLevel.Title))
				;

                CreateMap<ReportStore, ReportStoreListViewModel>()
											.ForMember(x => x.AccessLevelTitle, 
					b => b.MapFrom(c => c.AccessLevel.Title));

				CreateMap<ReportStore, ReportStoreViewModel>()
											.ForMember(x => x.AccessLevelTitle, 
					b => b.MapFrom(c => c.AccessLevel.Title));

				CreateMap<ReportStoreEditModel, ReportStore>();

                CreateMap<ReportStore, ReportStoreSimpleViewModel>();
	   
					
				CreateMap<ReportGroup, ReportGroupEditModel>()
				;

                CreateMap<ReportGroup, ReportGroupListViewModel>()
						;

				CreateMap<ReportGroup, ReportGroupViewModel>()
						;

				CreateMap<ReportGroupEditModel, ReportGroup>();

                CreateMap<ReportGroup, ReportGroupSimpleViewModel>();
	   
					
				CreateMap<UserReport, UserReportEditModel>()
									.ForMember(x => x.UserTitle, 
					b => b.MapFrom(c => c.User.UserName))
									.ForMember(x => x.ReportTitle, 
					b => b.MapFrom(c => c.Report.Title))
				;

                CreateMap<UserReport, UserReportListViewModel>()
											.ForMember(x => x.UserTitle, 
					b => b.MapFrom(c => c.User.UserName))					.ForMember(x => x.ReportTitle, 
					b => b.MapFrom(c => c.Report.Title));

				CreateMap<UserReport, UserReportViewModel>()
											.ForMember(x => x.UserTitle, 
					b => b.MapFrom(c => c.User.UserName))					.ForMember(x => x.ReportTitle, 
					b => b.MapFrom(c => c.Report.Title));

				CreateMap<UserReportEditModel, UserReport>();

                CreateMap<UserReport, UserReportSimpleViewModel>();
	   
					
				CreateMap<ReportGroupReport, ReportGroupReportEditModel>()
									.ForMember(x => x.ReportStoreTitle, 
					b => b.MapFrom(c => c.ReportStore.Title))
									.ForMember(x => x.ReportGroupTitle, 
					b => b.MapFrom(c => c.ReportGroup.Title))
				;

                CreateMap<ReportGroupReport, ReportGroupReportListViewModel>()
											.ForMember(x => x.ReportStoreTitle, 
					b => b.MapFrom(c => c.ReportStore.Title))					.ForMember(x => x.ReportGroupTitle, 
					b => b.MapFrom(c => c.ReportGroup.Title));

				CreateMap<ReportGroupReport, ReportGroupReportViewModel>()
											.ForMember(x => x.ReportStoreTitle, 
					b => b.MapFrom(c => c.ReportStore.Title))					.ForMember(x => x.ReportGroupTitle, 
					b => b.MapFrom(c => c.ReportGroup.Title));

				CreateMap<ReportGroupReportEditModel, ReportGroupReport>();

                CreateMap<ReportGroupReport, ReportGroupReportSimpleViewModel>();
	   
			}
	}
}
