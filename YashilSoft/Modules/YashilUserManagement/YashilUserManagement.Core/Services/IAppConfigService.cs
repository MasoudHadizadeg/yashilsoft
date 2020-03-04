			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilUserManagement.Core.Services
{
	public interface IAppConfigService : IGenericService<AppConfig>
    {
			string GetDescription(int id);		
	
    }
}      
 