			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
	public interface ICommonBaseDataService : IGenericService<CommonBaseData>
    {
			string GetExtendedProps(int id);		
			string GetDescription(int id);		
	
    }
}      
 