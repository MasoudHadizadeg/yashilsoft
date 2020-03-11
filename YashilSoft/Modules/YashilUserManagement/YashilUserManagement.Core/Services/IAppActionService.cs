			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilUserManagement.Core.Services
{
	public interface IAppActionService : IGenericService<AppAction, int>
    {
			string GetDescription(int id);		
	
    }
}      
 