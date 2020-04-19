
			using System.Linq;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilNews.Core.Services
{
	public interface IServiceService : IGenericService<Service,int>
    {
                 
        IQueryable<Service> GetByCustomFilter( int? parentId, int? appEntityId);
           
		
    }
}      
 