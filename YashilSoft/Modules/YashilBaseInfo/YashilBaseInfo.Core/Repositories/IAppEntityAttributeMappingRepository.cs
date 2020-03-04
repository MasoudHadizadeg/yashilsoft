			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilBaseInfo.Core.Repositories
{
	public interface IAppEntityAttributeMappingRepository : IGenericRepository<AppEntityAttributeMapping>
    {
    			string GetDefaultValue(int id);		
			string GetAllowedValues(int id);		
			string GetDescription(int id);		
	
    }
}      
 