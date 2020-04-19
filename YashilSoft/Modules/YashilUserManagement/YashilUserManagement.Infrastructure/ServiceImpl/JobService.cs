	using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
	public class JobService : GenericService<Job,int>, IJobService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IJobRepository _jobRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public JobService (IUnitOfWork unitOfWork, IJobRepository jobRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, jobRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_jobRepository = jobRepository;
			_userPrincipal = userPrincipal;
        }
    }
}      
 