			
using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface IRepresentationPersonRepository : IGenericRepository<RepresentationPerson,int>
    {
        IQueryable<RepresentationPerson> GetByRepresentationId(int representationId);
        IQueryable<RepresentationPerson> GetByCustomFilter(int? representationId, int? personId, int? postId);
    }
}      
 