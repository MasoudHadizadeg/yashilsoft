			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface ICoursesPlanningService : IGenericService<CoursesPlanning,int>
    {
        IQueryable<CoursesPlanning> GetByRepresentationId(int representationId);
    }
}      
 