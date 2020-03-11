			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilBaseInfo.Core.Repositories
{
	public interface IAppEntityAttributeRepository : IGenericRepository<AppEntityAttribute, int>
    {
    			string GetAllowedValues(int id);		
			string GetDescription(int id);		
	
    }
}      
 