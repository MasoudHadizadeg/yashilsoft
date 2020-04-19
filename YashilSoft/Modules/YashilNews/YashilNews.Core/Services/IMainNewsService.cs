
			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilNews.Core.Services
{
	public interface IMainNewsService : IGenericService<MainNews,int>
    {
                 
        IQueryable<MainNews> GetByCustomFilter( int? newsStoreId);
           
		
    }
}      
 