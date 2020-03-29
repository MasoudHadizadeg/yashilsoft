			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface ICoursePlanningService : IGenericService<CoursePlanning,int>
    {
        IQueryable<CoursePlanning> GetByRepresentationId(int representationId);
    }
}      
 