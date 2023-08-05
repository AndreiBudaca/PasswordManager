using PasswordManager.Services.AuthToken.Dto;

namespace PasswordManager.Services.AuthToken
{
    public interface IAuthTokenService
    {
        public void GenerateToken(UserAuthDto user);
    }
}
