			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilUserManagement.Core.Repositories
{
	public interface IApplicationRepository : IGenericRepository<Application>
    {
    			string GetDescription(int id);		
			string GetAdditionalInfo(int id);		
	
    }
}      
 