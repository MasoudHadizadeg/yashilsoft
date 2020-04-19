
			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilNews.Core.Services
{
	public interface INewsStoreService : IGenericService<NewsStore,int>
    {
                 
        IQueryable<NewsStore> GetByCustomFilter( int? serviceId, int? newsType, int? language);
           
		
    }
}      
 