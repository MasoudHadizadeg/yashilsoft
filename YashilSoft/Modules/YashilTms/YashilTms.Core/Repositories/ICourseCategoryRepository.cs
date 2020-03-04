			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface ICourseCategoryRepository : IGenericRepository<CourseCategory>
    {
    			string GetDescription(int id);		
	
    }
}      
 