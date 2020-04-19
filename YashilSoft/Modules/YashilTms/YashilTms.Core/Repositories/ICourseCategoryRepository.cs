
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Repositories
{
    public interface ICourseCategoryRepository : IGenericRepository<CourseCategory, int>
    {
        IQueryable<CourseCategory> GetByEducationalCenterId(int educationalCenterId);
        IQueryable<CourseCategory> GetByEducationalCenterMainCourseCategoryId(int educationalCenterMainCourseCategoryId);
        IQueryable<CourseCategory> GetRepresentationCourseCategories(int representationId);
        IQueryable<CourseCategory> GetRepresentationCourseCategories(int representationId, int courseCategoryId);
    }
}
