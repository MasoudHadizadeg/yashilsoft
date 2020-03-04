			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilTms.Core.Services
{
	public interface IRepresentationPersonService : IGenericService<RepresentationPerson>
    {
			string GetDescription(int id);		
	
    }
}      
 