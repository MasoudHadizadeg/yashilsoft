			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
	public interface IAppEntityAttributeMappingService : IGenericService<AppEntityAttributeMapping>
    {
			string GetDefaultValue(int id);		
			string GetAllowedValues(int id);		
			string GetDescription(int id);		
	
    }
}      
 