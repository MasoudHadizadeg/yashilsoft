			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
	public interface IAppEntityAttributeService : IGenericService<AppEntityAttribute>
    {
			string GetAllowedValues(int id);		
			string GetDescription(int id);		
	
    }
}      
 