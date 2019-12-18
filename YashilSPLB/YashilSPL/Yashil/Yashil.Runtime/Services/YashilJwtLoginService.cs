using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Yashil.Common.Core.Dtos;
using Yashil.Common.Core.Interfaces;
using Yashil.Runtime.Classes;

namespace Yashil.Runtime.Services
{
    public class YashilJwtLoginService : ILoginService
    {
        private readonly IYashilPasswordValidator<int> _yashilPasswordValidator;
        private readonly AppSettings _appSettings;

        public YashilJwtLoginService(IYashilPasswordValidator<int> yashilPasswordValidator, IOptions<AppSettings> configuration)
        {
            _yashilPasswordValidator = yashilPasswordValidator;
            _appSettings = configuration.Value;
        }

        public async Task<LoginResultModel> Login(LoginViewModel model)
        {
            var user = await _yashilPasswordValidator.ValidateUserAndPassword(model);

            if (user != null)
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                string secret = _appSettings.Secret; 
                double ExpireTimeDuration = 50; //TODO Fix This .Read From Config File
                var key = Encoding.ASCII.GetBytes(secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = user.ClaimsIdentity,
                    Expires = DateTime.UtcNow.AddMinutes(ExpireTimeDuration),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new LoginResultModel
                {
                    Succeeded = true,
                    Token = tokenHandler.WriteToken(token)
                };
            }

            return null;
        }
    }
}