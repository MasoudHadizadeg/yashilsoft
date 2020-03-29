
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Repositories
{
    public interface ICoursePlanningRepository : IGenericRepository<CoursePlanning, int>
    {
        IQueryable<CoursePlanning> GetByRepresentationId(int representationId);
    }
}
