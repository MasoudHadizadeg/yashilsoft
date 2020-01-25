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
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(YashilAppDbContext context, IUserPrincipal userPrincipal) : base(context, userPrincipal)
        {
        }

        public Task<User> GetUserByUserName(string userName)
        {
            return DbSet.Where(x => x.UserName == userName).FirstOrDefaultAsync();
        }

        public bool IsAdmin(int userId)
        {
            return DbSet.Count(x => x.UserRoleUser.Any(e => e.Role.Id == 1 && e.UserId == userId)) >= 1;
        }
    }
}