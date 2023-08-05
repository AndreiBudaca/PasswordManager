using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.APIs.Models.Authentication;
using PasswordManager.Services.AuthToken;
using PasswordManager.Services.AuthToken.Dto;
using PasswordManager.Services.Users;
using PasswordManager.Services.Users.Dto;

namespace PasswordManager.APIs.Controllers
{   
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthTokenService _tokenService;
        private readonly IUsersService _usersService;

        public AuthenticationController(IAuthTokenService tokenService, IUsersService usersService)
        {
            _tokenService = tokenService;
            _usersService = usersService;
        }

        [Route("signup")]
        [HttpPost]
        public async Task<ActionResult<UserCreatedModel>> SignUp([FromBody] UserSignInModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int id;
            try
            {
                id = await _usersService.CreateUser(new CreateUserDto
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return Ok(new UserCreatedModel
            {
                Id = id,
                FullName = $"{model.FirstName} {model.LastName}",
                Email = model.Email
            });
        }

        [Route("login")]
        [HttpPost]
        public ActionResult Login([FromBody] UserLoginModel user)
        {
            var validUser = _usersService.ValidateUser(new ValidateUserDto
            {
                Email = user.Email,
                Password = user.Password
            });

            if (!validUser)
                return BadRequest(new { Error = "Bad credentials" });

            var userInfo = _usersService.GetLoginInfo(user.Email);

            var authInfo = new UserAuthDto
            {
                Id = userInfo.Id,
                FullName = userInfo.FullName
            };

            _tokenService.GenerateToken(authInfo);

            return Ok(new UserAuthModel
            {
                Id = authInfo.Id,
                FullName = authInfo.FullName,
                Token = authInfo.Token
            });
        }
    }
}
