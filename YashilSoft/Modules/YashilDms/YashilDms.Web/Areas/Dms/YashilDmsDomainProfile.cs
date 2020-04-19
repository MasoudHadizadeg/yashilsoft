using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;
using AutoMapper;
using Yashil.Core.Entities;
using YashilDms.Web.Areas.Dms.ViewModels;

namespace YashilDms.Web.Areas.Dms
{
    public class YashilDmsProfile : Profile, IOrderedMapperProfile
    {
        public int Order => 1;

        public YashilDmsProfile()
        {
            CreateMap<DocFormat, DocFormatEditModel>();

            CreateMap<DocFormat, DocFormatListViewModel>()
                ;
            CreateMap<DocFormatEditModel, DocFormat>();

            CreateMap<DocFormat, DocFormatSimpleViewModel>();


            CreateMap<DocumentCategory, DocumentCategoryEditModel>();

            CreateMap<DocumentCategory, DocumentCategoryListViewModel>()
                .ForMember(x => x.AppEntityTitle,
                    b => b.MapFrom(c => c.AppEntity.Title))
                ;
            CreateMap<DocumentCategoryEditModel, DocumentCategory>();

            CreateMap<DocumentCategory, DocumentCategorySimpleViewModel>();


            CreateMap<AppDocument, AppDocumentEditModel>();

            CreateMap<AppDocument, AppDocumentListViewModel>()
                .ForMember(x => x.DocTypeTitle,
                    b => b.MapFrom(c => c.DocType.Title))
                ;
            CreateMap<AppDocumentEditModel, AppDocument>();

            CreateMap<AppDocument, AppDocumentSimpleViewModel>();


            CreateMap<DocType, DocTypeEditModel>()
                .ForMember(x => x.AppEntityId, b
                    => b.MapFrom(c => c.DocumentCategory.AppEntityId));

            CreateMap<DocType, DocTypeListViewModel>()
                .ForMember(x => x.AppEntityTitle,
                    b => b.MapFrom(c => c.DocumentCategory.AppEntity.Title))
                .ForMember(x => x.DocumentCategoryTitle,
                    b => b.MapFrom(c => c.DocumentCategory.Title))
                .ForMember(x => x.DocFormatTitle,
                    b => b.MapFrom(c => c.DocFormat.Title));
            CreateMap<DocType, DocTypeCustomViewModel>()
                .ForMember(x => x.AppEntityTitle,
                    b => b.MapFrom(c => c.DocumentCategory.AppEntity.Title))
                .ForMember(x => x.DocumentCategoryTitle,
                    b => b.MapFrom(c => c.DocumentCategory.Title))
                .ForMember(x => x.DocFormatTitle,
                    b => b.MapFrom(c => c.DocFormat.Title));
            CreateMap<DocTypeEditModel, DocType>();

            CreateMap<DocType, DocTypeSimpleViewModel>();
        }
    }
}