			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilBaseInfo.Core.Repositories
{
	public interface ICommonBaseDataRepository : IGenericRepository<CommonBaseData>
    {
    			string GetExtendedProps(int id);		
			string GetDescription(int id);		
	
    }
}      
 