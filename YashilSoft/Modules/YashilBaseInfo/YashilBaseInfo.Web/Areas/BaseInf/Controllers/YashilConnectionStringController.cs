using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilBaseInfo.Core.Services;
using YashilBaseInfo.Web.Areas.BaseInf.ViewModels;

namespace YashilBaseInfo.Web.Areas.BaseInf.Controllers
{
    public class YashilConnectionStringController : BaseController<YashilConnectionString, int,
        YashilConnectionStringListViewModel, YashilConnectionStringViewModel, YashilConnectionStringEditModel,
        YashilConnectionStringSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IYashilConnectionStringService _yashilConnectionStringService;

        public YashilConnectionStringController(IYashilConnectionStringService yashilConnectionStringService,
            IMapper mapper) : base(yashilConnectionStringService, mapper)
        {
            _mapper = mapper;
            _yashilConnectionStringService = yashilConnectionStringService;
        }
    }
}