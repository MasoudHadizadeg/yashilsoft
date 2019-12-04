using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YashilAuthenticationServer.ViewModels
{
  public class UserAuthViewModel
  {
    public int Id { get; set; }
    public string Token { get; set; }
  }

  public class LoginViewModel
  {
    public string UserName { get; set; }
    public string Password { get; set; }
  }
}
