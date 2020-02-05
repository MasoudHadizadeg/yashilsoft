	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilReport.Core.Services;
using  YashilReport.Web.Areas.Rpt.ViewModels;

namespace YashilReport.Web.Areas.Rpt.Controllers
{
	public class RoleReportController : BaseController<RoleReport ,int,RoleReportListViewModel,  RoleReportEditModel,RoleReportSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IRoleReportService _roleReportService;
        public RoleReportController(IRoleReportService roleReportService, IMapper mapper) : base(roleReportService, mapper)
        {
            _mapper=mapper;
            _roleReportService=roleReportService;
        }
    }
}      