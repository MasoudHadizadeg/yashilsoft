using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course, int>
    {
        IQueryable<Course> GetByEducationalCenterId(int educationalCenterId);
        IQueryable<Course> GetByRepresentationId(int representationId);
        IQueryable<Course> GetByCourseCategoryId(int courseCategoryId, bool hierarchical = true);
        IQueryable<Course> GetByMainCourseCategoryId(int educationalCenterMainCourseCategoryId);
        IQueryable<Course> GetRepresentationCourseByCategoryId(int representationId, int courseCategoryId, bool hierarchical);
    }
}