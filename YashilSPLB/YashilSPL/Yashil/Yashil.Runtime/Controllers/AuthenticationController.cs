using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Yashil.Common.Core.Dtos;
using Yashil.Common.Core.Interfaces;

namespace Yashil.Common.Web.Infrastructure.BaseClasses
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public AuthenticationController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<LoginResultModel> Authenticate([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await _loginService.Login(model);
                return loginResult;
            }
            return null;
        }
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