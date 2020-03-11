			
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilUserManagement.Core.Services
{
	public interface IPostService : IGenericService<Post, int>
    {
			string GetDescription(int id);		
	
    }
}      
 