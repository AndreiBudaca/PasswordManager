using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.APIs.Models.Account;
using PasswordManager.Services.Password;

namespace PasswordManager.APIs.Controllers
{
    [Route("api/password")]
    [ApiController]
    [Authorize]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordGeneratorService _passwordGeneratorService;

        public PasswordController(IPasswordGeneratorService passwordService)
        {
            _passwordGeneratorService = passwordService;
        }

        [HttpGet]
        public ActionResult<AccountModel[]> GetPasswords()
        {
            return Ok(new AccountModel[0]);
        }

        [HttpPost]
        public ActionResult CreatePassword([FromBody] AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpGet]
        [Route("generate")]
        public ActionResult<GeneratePasswordModel> GeneratePassword(
            [FromQuery] PasswordGenerateOptionsModel options)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (options.UseLowerAlpha) _passwordGeneratorService.SetLowerAlpha();
            if (options.UseUpperAlpha) _passwordGeneratorService.SetUpperAlpha();
            if (options.UseNumeric) _passwordGeneratorService.SetNumeric();
            if (options.UseSpecial) _passwordGeneratorService.SetSpecial();

            _passwordGeneratorService.SetLength(options.Length);

            return Ok(new GeneratePasswordModel
            {
                Password = _passwordGeneratorService.Generate()
            });
        }
    }
}
