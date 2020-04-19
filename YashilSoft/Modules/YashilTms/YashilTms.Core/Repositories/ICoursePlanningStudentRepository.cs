			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface ICoursePlanningStudentRepository : IGenericRepository<CoursePlanningStudent,int>
    {
		          
        IQueryable<CoursePlanningStudent> GetByCustomFilter( int? coursePlanningId, int? personId, int? studentStatus);
           
		
    }
}      
 