			using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
	public class CoursesPlanningStudentService : GenericService<CoursesPlanningStudent,int>, ICoursesPlanningStudentService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly ICoursesPlanningStudentRepository _coursesPlanningStudentRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public CoursesPlanningStudentService (IUnitOfWork unitOfWork, ICoursesPlanningStudentRepository coursesPlanningStudentRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, coursesPlanningStudentRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_coursesPlanningStudentRepository = coursesPlanningStudentRepository;
			_userPrincipal = userPrincipal;
        }
    }
}      
 