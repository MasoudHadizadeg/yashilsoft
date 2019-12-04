			
using System.Collections.Generic;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities; 

namespace YashilUserManagement.Core.Repositories
{
	public interface IMenuRepository : IGenericRepository<Menu>
    {
        Task<List<Menu>> GetUserMenus(int currentUserId);
    }
}      
