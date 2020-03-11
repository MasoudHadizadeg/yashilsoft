			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface ICourseRepository : IGenericRepository<Course,int>
    {
        IQueryable<Course> GetByEducationalCenterId(int educationalCenterId);
    }
}      
 