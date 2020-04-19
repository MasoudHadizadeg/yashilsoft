using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Repositories
{
    public interface ICoursePlanningRepository : IGenericRepository<CoursePlanning, int>
    {
        IQueryable<CoursePlanning> GetByRepresentationId(int representationId);
        IQueryable<CoursePlanning> GetByCourseCategoryId(int courseCategoryId, int representationId, bool hierarchical);
        IQueryable<CoursePlanning> GetByMainCourseCategoryId(int educationalCenterMainCourseCategoryId,
            int representationId);
    }
}