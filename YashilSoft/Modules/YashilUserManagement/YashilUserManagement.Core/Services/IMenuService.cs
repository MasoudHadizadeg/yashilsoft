			
using System.Collections.Generic;
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilUserManagement.Core.Services
{
	public interface IMenuService : IGenericService<Menu, int>
    {
        Task<List<Menu>> GetUserMenus(int currentUserId);
    }
}      
 