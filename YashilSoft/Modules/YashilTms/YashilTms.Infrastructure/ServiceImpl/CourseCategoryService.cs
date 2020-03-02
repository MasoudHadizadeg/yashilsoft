			using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
	public class CourseCategoryService : GenericService<CourseCategory,int>, ICourseCategoryService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseCategoryRepository _courseCategoryRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public CourseCategoryService (IUnitOfWork unitOfWork, ICourseCategoryRepository courseCategoryRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, courseCategoryRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_courseCategoryRepository = courseCategoryRepository;
			_userPrincipal = userPrincipal;
        }
    }
}      
 