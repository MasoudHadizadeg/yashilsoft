			using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
	public class CoursesPlanningService : GenericService<CoursesPlanning,int>, ICoursesPlanningService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly ICoursesPlanningRepository _coursesPlanningRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public CoursesPlanningService (IUnitOfWork unitOfWork, ICoursesPlanningRepository coursesPlanningRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, coursesPlanningRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_coursesPlanningRepository = coursesPlanningRepository;
			_userPrincipal = userPrincipal;
        }
    }
}      
 