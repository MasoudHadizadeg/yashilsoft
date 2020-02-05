	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilReport.Core.Services;
using  YashilReport.Web.Areas.Rpt.ViewModels;

namespace YashilReport.Web.Areas.Rpt.Controllers
{
	public class ReportGroupReportController : BaseController<ReportGroupReport ,int,ReportGroupReportListViewModel,  ReportGroupReportEditModel,ReportGroupReportSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IReportGroupReportService _reportGroupReportService;
        public ReportGroupReportController(IReportGroupReportService reportGroupReportService, IMapper mapper) : base(reportGroupReportService, mapper)
        {
            _mapper=mapper;
            _reportGroupReportService=reportGroupReportService;
        }
    }
}      