			
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Core.Entities;

namespace YashilUserManagement.Core.Services
{
	public interface IUserService : IGenericService<User>
    {
        Task<User> GetUserByUserName(string userName);
        void SetUserPass(string userUserName, byte[] passwordHash, byte[] passwordSalt);
        bool IsAdmin(int id);
        bool CheckExistsUserName(string userName);
    }
}      
