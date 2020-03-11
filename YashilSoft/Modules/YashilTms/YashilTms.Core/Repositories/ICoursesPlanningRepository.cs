
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Repositories
{
    public interface ICoursesPlanningRepository : IGenericRepository<CoursesPlanning, int>
    {
        IQueryable<CoursesPlanning> GetByRepresentationId(int representationId);
    }
}
