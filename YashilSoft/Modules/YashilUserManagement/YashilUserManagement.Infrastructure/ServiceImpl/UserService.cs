using System.Text;
using System.Threading.Tasks;
using Yashil.Common.Core.Classes;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Common.SharedKernel.Helpers;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
    public class UserService : GenericService<User, int>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IUserPrincipal _userPrincipal;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IUserPrincipal userPrincipal) : base(
            unitOfWork, userRepository, userPrincipal)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _userPrincipal = userPrincipal;
        }

        public Task<User> GetUserByUserName(string userName)
        {
            return _userRepository.GetUserByUserName(userName);
        }

        public bool IsAdmin(int userId)
        {
            return _userRepository.IsAdmin(userId);
        }

        public bool CheckExistsUserName(string userName)
        {
            return _userRepository.CheckExistsUserName(userName);
        }

        public User GetCurrentUserInfo()
        {
            return _userRepository.GetCurrentUserInfo();
        }

        public bool CheckExistsNationalCode(string nationalCode)
        {
            return _userRepository.CheckExistsNationalCode(nationalCode);
        }

        public void SetUserPass(string userUserName, byte[] passwordHash, byte[] passwordSalt)
        {
            var user = _userRepository.GetUserByUserName(userUserName).Result;
            user.Password = passwordHash;
            user.PasswordSalt = passwordSalt;
            _unitOfWork.Commit();
        }
    }
}