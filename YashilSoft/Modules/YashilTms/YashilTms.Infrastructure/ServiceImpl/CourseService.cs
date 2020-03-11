	using System.Linq;
    using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
	public class CourseService : GenericService<Course,int>, ICourseService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _courseRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public CourseService (IUnitOfWork unitOfWork, ICourseRepository courseRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, courseRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_courseRepository = courseRepository;
			_userPrincipal = userPrincipal;
        }

        public IQueryable<Course> GetByEducationalCenterId(int educationalCenterId)
        {
            return _courseRepository.GetByEducationalCenterId(educationalCenterId);
        }
    }
}      
 