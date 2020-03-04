			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilTms.Core.Repositories
{
	public interface IRepresentationPersonRepository : IGenericRepository<RepresentationPerson>
    {
    			string GetDescription(int id);		
	
    }
}      
 