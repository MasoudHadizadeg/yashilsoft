	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDms.Core.Services;
using  YashilDms.Web.Areas.Dms.ViewModels;

namespace YashilDms.Web.Areas.Dms.Controllers
{
	public class DocumentCategoryController : BaseController<DocumentCategory ,int,DocumentCategoryListViewModel, DocumentCategoryEditModel,DocumentCategorySimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IDocumentCategoryService _documentCategoryService;
        public DocumentCategoryController(IDocumentCategoryService documentCategoryService, IMapper mapper) : base(documentCategoryService, mapper)
        {
            _mapper=mapper;
            _documentCategoryService=documentCategoryService;
        }
    }
}      