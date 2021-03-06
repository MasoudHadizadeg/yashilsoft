			
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilUserManagement.Core.Repositories
{
	public interface IUserRepository : IGenericRepository<User, int>
    {
        Task<User> GetUserByUserName(string userName);
        bool IsAdmin(int userId);
        bool CheckExistsUserName(string userName);
        User GetCurrentUserInfo();
        bool CheckExistsNationalCode(string nationalCode);
    }
}      
