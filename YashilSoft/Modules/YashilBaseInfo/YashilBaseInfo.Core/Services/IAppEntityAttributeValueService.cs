			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
	public interface IAppEntityAttributeValueService : IGenericService<AppEntityAttributeValue>
    {
			string GetValue(int id);		
			string GetDescription(int id);		
	
    }
}      
 