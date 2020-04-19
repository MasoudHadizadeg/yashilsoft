
			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilNews.Core.Services
{
	public interface INewsKeywordService : IGenericService<NewsKeyword,int>
    {
                 
        IQueryable<NewsKeyword> GetByCustomFilter( int? newsStoreId, int? keywordId);
           
		
    }
}      
 