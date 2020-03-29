using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilTms.Core.Repositories;
using YashilTms.Core.Services;

namespace YashilTms.Infrastructure.ServiceImpl
{
    public class MainCourseCategoryService : GenericService<MainCourseCategory, int>, IMainCourseCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMainCourseCategoryRepository _mainCourseCategoryRepository;
        private readonly IUserPrincipal _userPrincipal;

        public MainCourseCategoryService(IUnitOfWork unitOfWork,
            IMainCourseCategoryRepository mainCourseCategoryRepository, IUserPrincipal userPrincipal)
            : base(unitOfWork, mainCourseCategoryRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _mainCourseCategoryRepository = mainCourseCategoryRepository;
            _userPrincipal = userPrincipal;
        }

        public IQueryable<MainCourseCategory> GetMainCourseCategoryNotAssignedToEducationalCenterAsync(int id)
        {
            return _mainCourseCategoryRepository.GetMainCourseCategoryNotAssignedToEducationalCenterAsync(id);
        }

        public IQueryable<MainCourseCategory> GetMainCourseCategoryAssignedToEducationalCenterAsync(int id)
        {
            return _mainCourseCategoryRepository.GetMainCourseCategoryAssignedToEducationalCenterAsync(id);
        }

        public IQueryable<MainCourseCategory> GetByEducationalCenterId(int id)
        {
            return _mainCourseCategoryRepository.GetByEducationalCenterId(id);
        }
    }
}