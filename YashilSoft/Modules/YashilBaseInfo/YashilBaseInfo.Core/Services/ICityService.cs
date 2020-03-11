			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilBaseInfo.Core.Services
{
	public interface ICityService : IGenericService<City, int>
    {
			string GetDescription(int id);		
	
    }
}      
 