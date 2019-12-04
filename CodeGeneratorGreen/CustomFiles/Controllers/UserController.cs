using System;
using System.Linq;
using System.Text;
using AppData.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using YashilAuthenticationServer.BaseClasses;
using YashilAuthenticationServer.Data;
using YashilAuthenticationServer.Helpers;
using YashilAuthenticationServer.ViewModels;

namespace YashilAuthenticationServer.Controllers
{
  /// <summary>
  /// Represents a User.
  /// NOTE: This class is generated from a T4 template - you should not modify it manually.
  /// </summary>
  public class UserController : BaseController<User, int, UserViewModel, UserEditModel>
  {
    private readonly AppSettings _appSettings;

    public UserController(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettings> configuration) : base(
      unitOfWork, unitOfWork.GetUserRepository(),
      mapper)
    {
      _appSettings = configuration.Value;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] LoginViewModel userParam)
    {
      try
      {
        SeedUser();

        var key = _appSettings.Secret;
        var token = UnitOfWork.GetUserRepository().Authenticate(userParam.UserName, userParam.Password, key);

        if (token == null)
          return BadRequest(new {message = "Username or password is incorrect"});
        var userAuthViewModel = new UserAuthViewModel
        {
          Id = 1,
          Token = token
        };
        return Ok(userAuthViewModel);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    private void SeedUser()
    {
      var adminUser = UnitOfWork.GetUserRepository().GetAll().FirstOrDefault(x => x.UserName == "admin");
      if (adminUser == null)
      {
        var user = new User
        {
          UserName = "admin",
          Email = "admin@iranleague.ir",
          FirstName = "admin",
          LastName = "admin"
        };
        CryptographyHelper.CreatePasswordHash("123", out var passwordHash, out var passwordSalt);

        user.Password = passwordHash;
        user.PasswordSalt = passwordSalt;
        user.OrganizationId = 1;
        Repo.Add(user);
        try
        {
          UnitOfWork.Commit();
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          throw;
        }
      }
    }

    protected override void CustomMapBeforeInsert(UserEditModel editModel, User entity)
    {
      entity.Password = Encoding.UTF8.GetBytes(editModel.PasswordStr);
      CryptographyHelper.CreatePasswordHash(editModel.PasswordStr, out var passwordHash, out var passwordSalt);

      entity.CreateDate = DateFunction.TodayShamsiInt();
      entity.CreateTime = DateFunction.GetTimeInt();

      entity.Password = passwordHash;
      entity.PasswordSalt = passwordSalt;

      base.CustomMapBeforeInsert(editModel, entity);
    }

    protected override void CustomMapBeforeUpdate(UserEditModel editModel, User entity)
    {
      if (!string.IsNullOrEmpty(editModel.PasswordStr))
      {
        entity.Password = Encoding.UTF8.GetBytes(editModel.PasswordStr);
        byte[] passwordHash, passwordSalt;
        CryptographyHelper.CreatePasswordHash(editModel.PasswordStr, out passwordHash, out passwordSalt);
        entity.Password = passwordHash;
        entity.PasswordSalt = passwordSalt;
      }

      base.CustomMapBeforeUpdate(editModel, entity);
    }

    protected override string[] GetNotModifiedProperties(User entity)
    {
      if (entity.Password == null)
      {
        return new string[] {"Password"};
      }

      return null;
    }

    [HttpGet("CheckUserName")]
    public object CheckUserName(string userName)
    {
      return Repo.GetAll().Any(x => x.UserName == userName);
    }
  }
}
