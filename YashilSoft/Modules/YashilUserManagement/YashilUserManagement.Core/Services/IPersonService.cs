			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilUserManagement.Core.Services
{
	public interface IPersonService : IGenericService<Person>
    {
			string GetDescription(int id);		
	
    }
}      
 