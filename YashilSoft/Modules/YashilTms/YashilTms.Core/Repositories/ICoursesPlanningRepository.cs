			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface ICoursesPlanningRepository : IGenericRepository<CoursesPlanning>
    {
    			string GetDescription(int id);		
	
    }
}      
 