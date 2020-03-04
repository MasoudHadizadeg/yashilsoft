			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilUserManagement.Core.Repositories
{
	public interface IAppActionRepository : IGenericRepository<AppAction>
    {
    			string GetDescription(int id);		
	
    }
}      
 