			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilUserManagement.Core.Repositories
{
	public interface IPersonRepository : IGenericRepository<Person>
    {
    			string GetDescription(int id);		
	
    }
}      
 