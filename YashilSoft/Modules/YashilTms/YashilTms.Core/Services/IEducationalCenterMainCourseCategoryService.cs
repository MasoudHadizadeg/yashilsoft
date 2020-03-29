using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
    public interface
        IEducationalCenterMainCourseCategoryService : IGenericService<EducationalCenterMainCourseCategory, int>
    {
        Task<bool> AssignSelectedItemsToEducationalCenter(List<int> ints, int groupId, bool assign);
        IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoriesByEducationalCenterId(int? id);
        IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoryByRepresentationId(int id);

        IQueryable<EducationalCenterMainCourseCategory> GetMainCourseCategoriesByCourseCategoryId(int courseCategoryId,
            bool hierarchical = true);
    }
}