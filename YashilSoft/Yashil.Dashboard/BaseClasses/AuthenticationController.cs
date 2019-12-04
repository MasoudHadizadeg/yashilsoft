using Microsoft.AspNetCore.Mvc;

namespace Yashil.Dashboard.Web.BaseClasses
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpGet("IsLogin")]
        public bool IsLogin()
        {
            if (User.Identity.IsAuthenticated && !string.IsNullOrEmpty(User.Identity.Name))
            {
                return true;
            }

            return false;
        }
    }
}