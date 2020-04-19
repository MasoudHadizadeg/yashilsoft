			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilNews.Core.Repositories
{
	public interface IServiceRepository : IGenericRepository<Service,int>
    {
		          
        IQueryable<Service> GetByCustomFilter( int? parentId, int? appEntityId);
           
		
    }
}      
 