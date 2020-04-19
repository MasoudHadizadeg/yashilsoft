			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface IRepresentationTeacherRepository : IGenericRepository<RepresentationTeacher,int>
    {
		          
        IQueryable<RepresentationTeacher> GetByCustomFilter( int? personId);
           
		
    }
}      
 