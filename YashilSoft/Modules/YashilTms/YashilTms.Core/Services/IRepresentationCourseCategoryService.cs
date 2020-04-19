
			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface IRepresentationCourseCategoryService : IGenericService<RepresentationCourseCategory,int>
    {
                 
        IQueryable<RepresentationCourseCategory> GetByCustomFilter( int? representationId, int? courseCategoryId);
           
		
    }
}      
 