
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;
using AutoMapper; 
using Yashil.Core.Entities;
using YashilDms.Web.Areas.Dms.ViewModels;

namespace YashilDms.Web.Areas.Dms
{

	public class YashilDmsProfile : Profile,IOrderedMapperProfile
		{
             public int Order => 1;
			 public YashilDmsProfile()
				{	
					
				CreateMap<DocFormat, DocFormatEditModel>()
				;

                CreateMap<DocFormat, DocFormatListViewModel>()
						;

				CreateMap<DocFormat, DocFormatViewModel>()
						;

				CreateMap<DocFormatEditModel, DocFormat>();

                CreateMap<DocFormat, DocFormatSimpleViewModel>();
	   
					
				CreateMap<DocumentCategory, DocumentCategoryEditModel>()
									.ForMember(x => x.AppEntityTitle, 
					b => b.MapFrom(c => c.AppEntity.Title))
				;

                CreateMap<DocumentCategory, DocumentCategoryListViewModel>()
											.ForMember(x => x.AppEntityTitle, 
					b => b.MapFrom(c => c.AppEntity.Title));

				CreateMap<DocumentCategory, DocumentCategoryViewModel>()
											.ForMember(x => x.AppEntityTitle, 
					b => b.MapFrom(c => c.AppEntity.Title));

				CreateMap<DocumentCategoryEditModel, DocumentCategory>();

                CreateMap<DocumentCategory, DocumentCategorySimpleViewModel>();
	   
					
				CreateMap<AppDocument, AppDocumentEditModel>()
									.ForMember(x => x.DocTypeTitle, 
					b => b.MapFrom(c => c.DocType.Title))
									.ForMember(x => x.DocumentCategoryTitle, 
					b => b.MapFrom(c => c.DocumentCategory.Title))
				;

                CreateMap<AppDocument, AppDocumentListViewModel>()
											.ForMember(x => x.DocTypeTitle, 
					b => b.MapFrom(c => c.DocType.Title))					.ForMember(x => x.DocumentCategoryTitle, 
					b => b.MapFrom(c => c.DocumentCategory.Title));

				CreateMap<AppDocument, AppDocumentViewModel>()
											.ForMember(x => x.DocTypeTitle, 
					b => b.MapFrom(c => c.DocType.Title))					.ForMember(x => x.DocumentCategoryTitle, 
					b => b.MapFrom(c => c.DocumentCategory.Title));

				CreateMap<AppDocumentEditModel, AppDocument>();

                CreateMap<AppDocument, AppDocumentSimpleViewModel>();
	   
					
				CreateMap<DocType, DocTypeEditModel>()
									.ForMember(x => x.AppEntityTitle, 
					b => b.MapFrom(c => c.AppEntity.Title))
									.ForMember(x => x.DocFormatTitle, 
					b => b.MapFrom(c => c.DocFormat.Title))
				;

                CreateMap<DocType, DocTypeListViewModel>()
											.ForMember(x => x.AppEntityTitle, 
					b => b.MapFrom(c => c.AppEntity.Title))					.ForMember(x => x.DocFormatTitle, 
					b => b.MapFrom(c => c.DocFormat.Title));

				CreateMap<DocType, DocTypeViewModel>()
											.ForMember(x => x.AppEntityTitle, 
					b => b.MapFrom(c => c.AppEntity.Title))					.ForMember(x => x.DocFormatTitle, 
					b => b.MapFrom(c => c.DocFormat.Title));

				CreateMap<DocTypeEditModel, DocType>();

                CreateMap<DocType, DocTypeSimpleViewModel>();
	   
			}
	}
}
