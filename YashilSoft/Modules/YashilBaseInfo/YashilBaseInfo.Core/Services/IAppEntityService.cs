			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
	public interface IAppEntityService : IGenericService<AppEntity, int>
    {
			string GetDescription(int id);		
			string GetProps(int id);		
	
    }
}      
 