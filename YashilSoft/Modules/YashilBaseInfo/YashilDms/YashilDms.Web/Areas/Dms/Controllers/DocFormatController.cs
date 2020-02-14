	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDms.Core.Services;
using  YashilDms.Web.Areas.Dms.ViewModels;

namespace YashilDms.Web.Areas.Dms.Controllers
{
	public class DocFormatController : BaseController<DocFormat ,int,DocFormatListViewModel, DocFormatViewModel, DocFormatEditModel,DocFormatSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IDocFormatService _docFormatService;
        public DocFormatController(IDocFormatService docFormatService, IMapper mapper) : base(docFormatService, mapper)
        {
            _mapper=mapper;
            _docFormatService=docFormatService;
        }
    }
}      