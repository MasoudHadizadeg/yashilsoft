	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilReport.Core.Services;
using  YashilReport.Web.Areas.Rpt.ViewModels;

namespace YashilReport.Web.Areas.Rpt.Controllers
{
	public class UserReportController : BaseController<UserReport ,int,UserReportListViewModel, UserReportViewModel, UserReportEditModel,UserReportSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserReportService _userReportService;
        public UserReportController(IUserReportService userReportService, IMapper mapper) : base(userReportService, mapper)
        {
            _mapper=mapper;
            _userReportService=userReportService;
        }
    }
}      