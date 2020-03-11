			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilBaseInfo.Core.Repositories
{
	public interface ICityRepository : IGenericRepository<City, int>
    {
    			string GetDescription(int id);		
	
    }
}      
 