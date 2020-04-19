			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilNews.Core.Repositories
{
	public interface INewsKeywordRepository : IGenericRepository<NewsKeyword,int>
    {
		          
        IQueryable<NewsKeyword> GetByCustomFilter( int? newsStoreId, int? keywordId);
           
		
    }
}      
 