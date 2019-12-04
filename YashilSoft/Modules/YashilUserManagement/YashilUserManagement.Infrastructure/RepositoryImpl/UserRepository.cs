using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using Yashil.Infrastructure.Data;
using YashilUserManagement.Core.Repositories;

namespace YashilUserManagement.Infrastructure.RepositoryImpl
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(YashilAppDbContext context) : base(context)
        {
        }

        public Task<User> GetUserByUserName(string userName)
        {
            return DbSet.Where(x => x.UserName == userName).FirstOrDefaultAsync();
        }
    }
}