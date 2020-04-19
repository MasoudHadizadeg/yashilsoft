			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilNews.Core.Repositories
{
	public interface IMainNewsRepository : IGenericRepository<MainNews,int>
    {
		          
        IQueryable<MainNews> GetByCustomFilter( int? newsStoreId);
           
		
    }
}      
 