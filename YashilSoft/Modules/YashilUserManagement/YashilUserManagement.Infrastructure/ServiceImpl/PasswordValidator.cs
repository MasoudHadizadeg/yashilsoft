using System.Security.Claims;
using System.Threading.Tasks;
using Yashil.Common.Core.Dtos;
using Yashil.Common.Core.Interfaces;
using Yashil.Common.SharedKernel.Helpers;
using Yashil.Core.Classes;
using YashilUserManagement.Core.Services;

namespace YashilUserManagement.Infrastructure.ServiceImpl
{
    public class PasswordValidator : IYashilPasswordValidator<int>
    {
        private readonly IUserService _userService;

        public PasswordValidator(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserValidationResaultViewModel<int>> ValidateUserAndPassword(LoginViewModel loginViewModel)
        {
            var user = await _userService.GetUserByUserName(loginViewModel.UserName);
            if (user != null)
            {
                var passwordBytes = user.Password;
                var passwordSalt = user.PasswordSalt;
                if (CryptographyHelper.VerifyPasswordHash(loginViewModel.Password + loginViewModel.UserName,
                    passwordBytes, passwordSalt))
                {
                    var isAdmin = _userService.IsAdmin(user.Id);
                    var claimsIdentity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, user.Id.ToString()),
                        new Claim(YashilClaimTypes.ApplicationId, user.ApplicationId.ToString()),
                        new Claim(YashilClaimTypes.IsAdmin, isAdmin.ToString()),
                        new Claim(ClaimTypes.Surname, $"{user.FirstName} {user.LastName}")
                    });
                    if (user.OrganizationId.HasValue)
                    {
                        claimsIdentity.AddClaim(new Claim(YashilClaimTypes.OrganizationId,
                            user.OrganizationId.ToString()));
                    }

                    return new UserValidationResaultViewModel<int>
                    {
                        ClaimsIdentity = claimsIdentity,
                        IsSuccess = true,
                        UserId = user.Id,
                        UserName = user.UserName
                    };
                }
            }

            return null;
        }
    }
}