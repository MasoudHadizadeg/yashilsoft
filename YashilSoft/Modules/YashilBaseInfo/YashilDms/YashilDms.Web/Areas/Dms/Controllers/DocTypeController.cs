	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDms.Core.Services;
using  YashilDms.Web.Areas.Dms.ViewModels;

namespace YashilDms.Web.Areas.Dms.Controllers
{
	public class DocTypeController : BaseController<DocType ,int,DocTypeListViewModel, DocTypeViewModel, DocTypeEditModel,DocTypeSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IDocTypeService _docTypeService;
        public DocTypeController(IDocTypeService docTypeService, IMapper mapper) : base(docTypeService, mapper)
        {
            _mapper=mapper;
            _docTypeService=docTypeService;
        }
    }
}      