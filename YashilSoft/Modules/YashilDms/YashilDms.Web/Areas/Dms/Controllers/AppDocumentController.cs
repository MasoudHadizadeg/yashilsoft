	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilDms.Core.Services;
using  YashilDms.Web.Areas.Dms.ViewModels;

namespace YashilDms.Web.Areas.Dms.Controllers
{
	public class AppDocumentController : BaseController<AppDocument ,int,AppDocumentListViewModel, AppDocumentEditModel,AppDocumentSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppDocumentService _appDocumentService;
        public AppDocumentController(IAppDocumentService appDocumentService, IMapper mapper) : base(appDocumentService, mapper)
        {
            _mapper=mapper;
            _appDocumentService=appDocumentService;
        }
    }
}      