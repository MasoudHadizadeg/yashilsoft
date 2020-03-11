			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilUserManagement.Core.Repositories
{
	public interface IPostRepository : IGenericRepository<Post, int>
    {
    			string GetDescription(int id);		
	
    }
}      
 