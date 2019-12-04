	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilReport.Core.Services;
using  YashilReport.Web.Areas.Rpt.ViewModels;

namespace YashilReport.Web.Areas.Rpt.Controllers
{
	public class ReportGroupController : BaseController<ReportGroup ,int,ReportGroupListViewModel, ReportGroupViewModel, ReportGroupEditModel,ReportGroupSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IReportGroupService _reportGroupService;
        public ReportGroupController(IReportGroupService reportGroupService, IMapper mapper) : base(reportGroupService, mapper)
        {
            _mapper=mapper;
            _reportGroupService=reportGroupService;
        }
    }
}      