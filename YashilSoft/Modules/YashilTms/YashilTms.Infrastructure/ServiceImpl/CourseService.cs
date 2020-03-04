using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
    public class CourseService : GenericService<Course, int>, ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserPrincipal _userPrincipal;

        public CourseService(IUnitOfWork unitOfWork, ICourseRepository courseRepository, IUserPrincipal userPrincipal)
            : base(unitOfWork, courseRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
            _userPrincipal = userPrincipal;
        }

        public string GetDescription(int id)
        {
            return _courseRepository.GetDescription(id);
        }

        public string GetTopic(int id)
        {
            return _courseRepository.GetTopic(id);
        }

        public string GetPrerequisite(int id)
        {
            return _courseRepository.GetPrerequisite(id);
        }

        public string GetTarget(int id)
        {
            return _courseRepository.GetTarget(id);
        }

        public string GetRequirements(int id)
        {
            return _courseRepository.GetRequirements(id);
        }

        public string GetSkill(int id)
        {
            return _courseRepository.GetSkill(id);
        }

        public string GetAudience(int id)
        {
            return _courseRepository.GetAudience(id);
        }
    }
}