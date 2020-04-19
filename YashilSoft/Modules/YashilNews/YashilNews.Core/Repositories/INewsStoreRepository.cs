			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilNews.Core.Repositories
{
	public interface INewsStoreRepository : IGenericRepository<NewsStore,int>
    {
		          
        IQueryable<NewsStore> GetByCustomFilter( int? serviceId, int? newsType, int? language);
           
		
    }
}      
 