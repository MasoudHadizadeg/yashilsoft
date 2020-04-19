using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Repositories
{
    public interface ICoursePlanningRepository : IGenericRepository<CoursePlanning, int>
    {

        IQueryable<CoursePlanning> GetByCustomFilter(int? representationId, int? courseStatus, int? representationTeacherId, int? courseId, int? ageCategory, int? implementationType, int? courseType, int? runType, int? customGender);
        IQueryable<CoursePlanning> GetByRepresentationId(int representationId);
        IQueryable<CoursePlanning> GetByCourseCategoryId(int courseCategoryId, bool hierarchical);
        IQueryable<CoursePlanning> GetByMainCourseCategoryId(int educationalCenterMainCourseCategoryId);

    }
}
