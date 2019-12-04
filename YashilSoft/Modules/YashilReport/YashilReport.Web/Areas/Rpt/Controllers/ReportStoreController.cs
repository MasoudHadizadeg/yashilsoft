	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilReport.Core.Services;
using  YashilReport.Web.Areas.Rpt.ViewModels;

namespace YashilReport.Web.Areas.Rpt.Controllers
{
	public class ReportStoreController : BaseController<ReportStore ,int,ReportStoreListViewModel, ReportStoreViewModel, ReportStoreEditModel,ReportStoreSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IReportStoreService _reportStoreService;
        public ReportStoreController(IReportStoreService reportStoreService, IMapper mapper) : base(reportStoreService, mapper)
        {
            _mapper=mapper;
            _reportStoreService=reportStoreService;
        }
    }
}      