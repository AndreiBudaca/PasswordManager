using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PasswordManager.Services.AuthToken.Dto;
using PasswordManager.Services.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PasswordManager.Services.AuthToken
{
    public class AuthTokenService : IAuthTokenService
    {
        private readonly TokenAuthenticationOptions _options;

        public AuthTokenService(IOptions<TokenAuthenticationOptions> options)
        {
            _options = options.Value;
        }

        public void GenerateToken(UserAuthDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_options.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_options.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
        }
    }
}
