			
using System.Collections.Generic;
using System.Threading.Tasks;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
	public class MenuService : GenericService<Menu,int>, IMenuService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IMenuRepository _menuRepository;
       
		public MenuService (IUnitOfWork unitOfWork, IMenuRepository menuRepository, IUserPrincipal userPrincipal) : base(unitOfWork, menuRepository,userPrincipal)
        {
			_unitOfWork = unitOfWork;
			_menuRepository = menuRepository;
        }
        public async Task<List<Menu>> GetUserMenus(int currentUserId)
        {
            return await _menuRepository.GetUserMenus(currentUserId);
        }
    }
}      
 