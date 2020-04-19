using System.Linq;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
    public class CoursePlanningService : GenericService<CoursePlanning, int>, ICoursePlanningService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoursePlanningRepository _coursePlanningRepository;
        private readonly IUserPrincipal _userPrincipal;

        public CoursePlanningService(IUnitOfWork unitOfWork, ICoursePlanningRepository coursePlanningRepository, IUserPrincipal userPrincipal)
            : base(unitOfWork, coursePlanningRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _coursePlanningRepository = coursePlanningRepository;
            _userPrincipal = userPrincipal;
        }

        public IQueryable<CoursePlanning> GetByCustomFilter(int? representationId, int? courseStatus, int? representationTeacherId, int? courseId, int? ageCategory, int? implementationType, int? courseType, int? runType, int? customGender)
        {
            return _coursePlanningRepository.GetByCustomFilter(representationId, courseStatus, representationTeacherId, courseId, ageCategory, implementationType, courseType, runType, customGender);
        }
        public IQueryable<CoursePlanning> GetByRepresentationId(int representationId)
        {
            return _coursePlanningRepository.GetByRepresentationId(representationId);
        }

        public IQueryable<CoursePlanning> GetByCourseCategoryId(int courseCategoryId, bool hierarchical = true)
        {
            return _coursePlanningRepository.GetByCourseCategoryId(courseCategoryId, hierarchical);
        }

        public IQueryable<CoursePlanning> GetByMainCourseCategoryId(int educationalCenterMainCourseCategoryId)
        {
            return _coursePlanningRepository.GetByMainCourseCategoryId(educationalCenterMainCourseCategoryId);
        }

    }
}
