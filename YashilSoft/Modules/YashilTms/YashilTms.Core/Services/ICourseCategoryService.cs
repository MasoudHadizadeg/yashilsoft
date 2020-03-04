			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface ICourseCategoryService : IGenericService<CourseCategory>
    {
			string GetDescription(int id);		
	
    }
}      
 