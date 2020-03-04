			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilUserManagement.Core.Services
{
	public interface IAppActionService : IGenericService<AppAction>
    {
			string GetDescription(int id);		
	
    }
}      
 