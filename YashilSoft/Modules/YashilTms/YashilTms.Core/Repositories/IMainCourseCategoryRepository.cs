			
using System.Collections.Generic;
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface IMainCourseCategoryRepository : IGenericRepository<MainCourseCategory,int>
    {
        IQueryable<MainCourseCategory> GetMainCourseCategoryNotAssignedToEducationalCenterAsync(int id);
        IQueryable<MainCourseCategory> GetMainCourseCategoryAssignedToEducationalCenterAsync(int id);
        IQueryable<MainCourseCategory> GetByEducationalCenterId(int id);
    }
}      
 