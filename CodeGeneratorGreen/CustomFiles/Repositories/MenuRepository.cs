using System.Linq;
using AppData.Contexts;
using AppData.Models;
using YashilData.Data;

namespace YashilAuthenticationServer.Repositories
{
    public interface IMenuRepository : IGenericRepository<Menu>
    {
        IQueryable<Menu> GenerateMenu(int userId);
    }

    public class MenuRepository : GenericRepository<Menu, int>, IMenuRepository
    {
        public MenuRepository(TLSAppDbContext context) : base(context)
        {
        }

        public IQueryable<Menu> GenerateMenu(int userId)
        {
            //list.ProjectTo<TViewModel>(_mapper.ConfigurationProvider)
            var userRoles = _context.Set<UserRole>().Where(t => t.UserId == userId).Select(x => x.RoleId);
            var resources = _context.Set<RoleResourceAction>().Where(x => userRoles.Contains(x.RoleId))
                .Select(x => x.ResourceAction.ResourceId);
            return GetAll().Where(x => !x.ResourceId.HasValue || resources.Contains(x.ResourceId.Value));
        }
    }
}