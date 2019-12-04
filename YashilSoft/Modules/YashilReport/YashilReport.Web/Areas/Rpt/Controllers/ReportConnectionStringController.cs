	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilReport.Core.Services;
using  YashilReport.Web.Areas.Rpt.ViewModels;

namespace YashilReport.Web.Areas.Rpt.Controllers
{
	public class ReportConnectionStringController : BaseController<ReportConnectionString ,int,ReportConnectionStringListViewModel, ReportConnectionStringViewModel, ReportConnectionStringEditModel,ReportConnectionStringSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IReportConnectionStringService _reportConnectionStringService;
        public ReportConnectionStringController(IReportConnectionStringService reportConnectionStringService, IMapper mapper) : base(reportConnectionStringService, mapper)
        {
            _mapper=mapper;
            _reportConnectionStringService=reportConnectionStringService;
        }
    }
}      