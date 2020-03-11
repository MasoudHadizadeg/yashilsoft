			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilBaseInfo.Core.Repositories
{
	public interface ICommonBaseTypeRepository : IGenericRepository<CommonBaseType, int>
    {
    			string GetDescription(int id);		
	
    }
}      
 