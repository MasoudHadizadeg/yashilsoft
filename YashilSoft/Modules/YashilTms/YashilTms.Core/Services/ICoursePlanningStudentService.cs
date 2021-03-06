
			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface ICoursePlanningStudentService : IGenericService<CoursePlanningStudent,int>
    {
                 
        IQueryable<CoursePlanningStudent> GetByCustomFilter( int? coursePlanningId, int? personId, int? studentStatus);
           
		
    }
}      
 