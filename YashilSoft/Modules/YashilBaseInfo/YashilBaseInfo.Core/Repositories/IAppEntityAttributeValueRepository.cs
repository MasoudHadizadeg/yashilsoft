			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilBaseInfo.Core.Repositories
{
	public interface IAppEntityAttributeValueRepository : IGenericRepository<AppEntityAttributeValue, int>
    {
    			string GetValue(int id);		
			string GetDescription(int id);		
	
    }
}      
 