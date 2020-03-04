	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using  YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf.Controllers
{
	public class AppEntityAttributeController : BaseController<AppEntityAttribute ,int,AppEntityAttributeListViewModel, AppEntityAttributeEditModel,AppEntityAttributeSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAppEntityAttributeService _appEntityAttributeService;
        public AppEntityAttributeController(IAppEntityAttributeService appEntityAttributeService, IMapper mapper) : base(appEntityAttributeService, mapper)
        {
            _mapper=mapper;
            _appEntityAttributeService=appEntityAttributeService;
        }
    }
}      