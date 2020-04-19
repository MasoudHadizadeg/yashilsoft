using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Repositories
{
    public interface IEducationalCenterMainCourseCategoryRepository : IGenericRepository<EducationalCenterMainCourseCategory, int>
    {
        Task AssignSelectedItemsToEducationalCenter(List<int> mainCourseCategories, int educationalCenterId,
            bool assign);

        IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoriesByEducationalCenterId(int? id);
        IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoryByRepresentationId(int representationId);

        IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoriesByCourseCategoryId(int courseCategoryId, in bool hierarchical = true);
        IQueryable<EducationalCenterMainCourseCategory> GetByCustomFilter(int? educationalCenterId, int? mainCourseCategoryId);
    }
}