	using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
	public class RepresentationCourseCategoryService : GenericService<RepresentationCourseCategory,int>, IRepresentationCourseCategoryService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IRepresentationCourseCategoryRepository _representationCourseCategoryRepository;
		private readonly IUserPrincipal _userPrincipal;
       
		public RepresentationCourseCategoryService (IUnitOfWork unitOfWork, IRepresentationCourseCategoryRepository representationCourseCategoryRepository, IUserPrincipal userPrincipal)
			: base(unitOfWork, representationCourseCategoryRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_representationCourseCategoryRepository = representationCourseCategoryRepository;
			_userPrincipal = userPrincipal;
        }
                 
        public IQueryable<RepresentationCourseCategory> GetByCustomFilter( int? representationId, int? courseCategoryId)
        {
            return _representationCourseCategoryRepository.GetByCustomFilter(representationId,courseCategoryId);
        }
           

    }
}      
 