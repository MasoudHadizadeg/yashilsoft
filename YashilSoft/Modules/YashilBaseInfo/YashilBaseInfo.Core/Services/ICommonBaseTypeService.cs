			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
	public interface ICommonBaseTypeService : IGenericService<CommonBaseType>
    {
			string GetDescription(int id);		
	
    }
}      
 