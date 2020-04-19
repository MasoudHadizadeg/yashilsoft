
			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface IRepresentationTeacherService : IGenericService<RepresentationTeacher,int>
    {
                 
        IQueryable<RepresentationTeacher> GetByCustomFilter( int? personId);
           
		
    }
}      
 