			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilUserManagement.Core.Repositories
{
	public interface IAppConfigRepository : IGenericRepository<AppConfig, int>
    {
    			string GetDescription(int id);		
	
    }
}      
 