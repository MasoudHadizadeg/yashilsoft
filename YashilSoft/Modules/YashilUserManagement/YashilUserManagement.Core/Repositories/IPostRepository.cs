			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilUserManagement.Core.Repositories
{
	public interface IPostRepository : IGenericRepository<Post>
    {
    			string GetDescription(int id);		
	
    }
}      
 