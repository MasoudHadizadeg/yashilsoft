	 
using AutoMapper;
using Yashil.Common.Web.Infrastructure.BaseClasses;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Services;
using  YashilUserManagement.Web.Areas.UserMng.ViewModels;

namespace YashilUserManagement.Web.Areas.UserMng.Controllers
{
	public class JobController : BaseController<Job ,int,JobListViewModel, JobEditModel,JobSimpleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IJobService _jobService;
        public JobController(IJobService jobService, IMapper mapper) : base(jobService, mapper)
        {
            _mapper=mapper;
            _jobService=jobService;
        }
    }
}      