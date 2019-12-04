			
using System.Threading.Tasks;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.Infrastructure.Implementations;
using Yashil.Core.Entities;
using YashilUserManagement.Core.Repositories;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
	public class UserService : GenericService<User,int>, IUserService
    {
		private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
       
		public UserService (IUnitOfWork unitOfWork, IUserRepository userRepository) : base(unitOfWork, userRepository)
        {
			_unitOfWork = unitOfWork;
			_userRepository = userRepository;
        }

        public Task<User> GetUserByUserName(string userName)
        {
            return _userRepository.GetUserByUserName(userName);
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
