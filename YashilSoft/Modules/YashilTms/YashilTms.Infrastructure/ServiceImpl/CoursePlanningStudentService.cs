	using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
	public class CoursePlanningStudentService : GenericService<CoursePlanningStudent,int>, ICoursePlanningStudentService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly ICoursePlanningStudentRepository _coursePlanningStudentRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public CoursePlanningStudentService (IUnitOfWork unitOfWork, ICoursePlanningStudentRepository coursePlanningStudentRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, coursePlanningStudentRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_coursePlanningStudentRepository = coursePlanningStudentRepository;
			_userPrincipal = userPrincipal;
        }
                 
        public IQueryable<CoursePlanningStudent> GetByCustomFilter( int? coursePlanningId, int? personId, int? studentStatus)
        {
            return _coursePlanningStudentRepository.GetByCustomFilter(coursePlanningId,personId,studentStatus);
        }
           

    }
}      
 