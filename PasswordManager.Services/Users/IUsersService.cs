using PasswordManager.Services.Users.Dto;

namespace PasswordManager.Services.Users
{
    public interface IUsersService
    {
        UserLoginInfoDto GetLoginInfo(string email);
        bool ValidateUser(ValidateUserDto user);
        Task<int> CreateUser(CreateUserDto user);
    }
}
