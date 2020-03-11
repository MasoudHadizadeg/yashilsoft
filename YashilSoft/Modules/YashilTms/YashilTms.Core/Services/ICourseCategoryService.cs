			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface ICourseCategoryService : IGenericService<CourseCategory,int>
    {
        IQueryable<CourseCategory> GetByEducationalCenterId(int educationalCenterId);
    }
}      
 