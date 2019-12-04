namespace Yashil.Dashboard.Web.ViewModels
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
