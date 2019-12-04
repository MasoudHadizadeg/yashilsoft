using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AppData.Contexts;
using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using YashilAuthenticationServer.Helpers;
using YashilData.Data;

namespace YashilAuthenticationServer.Repositories
{
  public interface IUserRepository : IGenericRepository<User>
  {
    string Authenticate(string username, string password, string secret);
    Organization GetCurrentUserOrganization(int userId);
  }

  public class UserRepository : GenericRepository<User, int>, IUserRepository
  {
    public UserRepository(TLSAppDbContext context) : base(context)
    {
    }

    public string Authenticate(string username, string password, string secret)
    {
      var user = GetAll().SingleOrDefault(x => x.UserName == username);

      if (user != null)
      {
        var passwordBytes = user.Password;
        var passwordSalt = user.PasswordSalt;

        if (CryptographyHelper.VerifyPasswordHash(password, passwordBytes, passwordSalt))
        {
          // authentication successful so generate jwt token
          var tokenHandler = new JwtSecurityTokenHandler();
          var key = Encoding.ASCII.GetBytes(secret);
          var tokenDescriptor = new SecurityTokenDescriptor
          {
            Subject = new ClaimsIdentity(new[]
            {
              new Claim(ClaimTypes.Name, user.Id.ToString()),
              new Claim("organization_id", GetCurrentUserOrganization(user.Id).ParentId.ToString()),
            }),
            Expires = DateTime.UtcNow.AddMinutes(60),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
              SecurityAlgorithms.HmacSha256Signature)
          };
          var token = tokenHandler.CreateToken(tokenDescriptor);
          return tokenHandler.WriteToken(token);
        }
      }

      return null;
    }

    public Organization GetCurrentUserOrganization(int userId)
    {
      return _context.Set<User>().Include(x => x.Organization).FirstOrDefault(x => x.Id == userId)?.Organization;
    }
  }
}
