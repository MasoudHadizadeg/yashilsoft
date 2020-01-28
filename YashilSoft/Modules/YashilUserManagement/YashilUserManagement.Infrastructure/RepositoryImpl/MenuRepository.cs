using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Core.Classes;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
    public class MenuRepository : GenericApplicationBasedRepository<Menu, int>, IMenuRepository
    {
        private readonly YashilAppDbContext _context;

        public MenuRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
        {
            _context = context;
        }

        public Task<List<Menu>> GetUserMenus(int userId)
        {
            var userRoles = _context.Set<UserRole>().Where(t => t.UserId == userId).Select(x => x.RoleId);
            var resources = _context.Set<RoleResourceAction>().Where(x => userRoles.Contains(x.RoleId))
                .Select(x => x.ResourceAction.ResourceId);
            return GetAll().Where(x => !x.ResourceId.HasValue || resources.Contains(x.ResourceId.Value)).ToListAsync();
        }
    }
}