			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilUserManagement.Core.Services
{
	public interface IApplicationService : IGenericService<Application>
    {
			string GetDescription(int id);		
			string GetAdditionalInfo(int id);		
	
    }
}      
 