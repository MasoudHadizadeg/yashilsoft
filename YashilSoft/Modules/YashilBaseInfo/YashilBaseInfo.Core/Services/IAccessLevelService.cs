			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
	public interface IAccessLevelService : IGenericService<AccessLevel>
    {
			string GetDescription(int id);		
	
    }
}      
 