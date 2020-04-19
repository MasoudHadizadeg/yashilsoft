			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface IRepresentationCourseCategoryRepository : IGenericRepository<RepresentationCourseCategory,int>
    {
		          
        IQueryable<RepresentationCourseCategory> GetByCustomFilter( int? representationId, int? courseCategoryId);
           
		
    }
}      
 