			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
	public interface ICommonBaseTypeService : IGenericService<CommonBaseType, int>
    {
			string GetDescription(int id);		
	
    }
}      
 