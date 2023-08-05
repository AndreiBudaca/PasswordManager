using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.APIs.Models.Authentication;
using PasswordManager.Services.AuthToken;
using PasswordManager.Services.AuthToken.Dto;

namespace PasswordManager.APIs.Controllers
{   
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthTokenService _tokenService;

        public AuthenticationController(IAuthTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [Route("signin")]
        [HttpPost]
        public ActionResult SignIn([FromBody] UserSignInModel model)
        {
            return Ok();
        }

        [Route("login")]
        [HttpPost]
        public ActionResult Login()
        {
            var user = new UserAuthDto() { Id = 0, FullName = "Test" };
            _tokenService.GenerateToken(user);

            return Ok(user);
        }
    }
}
