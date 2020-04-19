using System;
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
    public class EducationalCenterMainCourseCategoryService : GenericService<EducationalCenterMainCourseCategory, int>,
        IEducationalCenterMainCourseCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEducationalCenterMainCourseCategoryRepository _educationalCenterMainCourseCategoryRepository;
        private readonly IUserPrincipal _userPrincipal;

        public EducationalCenterMainCourseCategoryService(IUnitOfWork unitOfWork,
            IEducationalCenterMainCourseCategoryRepository educationalCenterMainCourseCategoryRepository,
            IUserPrincipal userPrincipal)
            : base(unitOfWork, educationalCenterMainCourseCategoryRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _educationalCenterMainCourseCategoryRepository = educationalCenterMainCourseCategoryRepository;
            _userPrincipal = userPrincipal;
        }

        public async Task<bool> AssignSelectedItemsToEducationalCenter(List<int> mainCourseCategories,
            int educationalCenterId, bool assign)
        {
            await _educationalCenterMainCourseCategoryRepository.AssignSelectedItemsToEducationalCenter(
                mainCourseCategories, educationalCenterId, assign);
            try
            {
                await SaveChangeAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoriesByEducationalCenterId(int? id)
        {
            return _educationalCenterMainCourseCategoryRepository.GetMainCourseCategoriesByEducationalCenterId(id);
        }
        public IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoryByRepresentationId(int id)
        {
            return _educationalCenterMainCourseCategoryRepository.GetMainCourseCategoryByRepresentationId(id);
        }

        public IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoriesByCourseCategoryId(int courseCategoryId, bool hierarchical = true)
        {
            return _educationalCenterMainCourseCategoryRepository.GetMainCourseCategoriesByCourseCategoryId(courseCategoryId, hierarchical);
        }
        public IQueryable<EducationalCenterMainCourseCategory> GetByCustomFilter(int? educationalCenterId, int? mainCourseCategoryId)
        {
            return _educationalCenterMainCourseCategoryRepository.GetByCustomFilter(educationalCenterId, mainCourseCategoryId);
        }

    }
}