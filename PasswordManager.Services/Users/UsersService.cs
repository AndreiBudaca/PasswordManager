using PasswordManager.Data;
using PasswordManager.Data.Entities;
using PasswordManager.Services.Users.Dto;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PasswordManager.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly PasswordManagerDbContext _dbContext;

        public UsersService(PasswordManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool ValidateUser(ValidateUserDto user)
        {
            var storedUser = _dbContext.Users
                .Where(dbUser => dbUser.Email == user.Email)
                .FirstOrDefault();

            if (storedUser == null)
                return false;

            var passHash = PasswordGenerator.GeneratePasswordHash(user.Password, storedUser.Salt);
            return passHash == storedUser.PasswordHash;
        }

        public UserLoginInfoDto GetLoginInfo(string email)
        {
            var info = _dbContext.Users
                .Where(user => user.Email == email)
                .Select(user => new UserLoginInfoDto
                {
                    Id = user.Id,
                    FullName = $"{user.FirstName} {user.LastName}"
                }).FirstOrDefault() ??
                throw new Exception("User does not exist");

            return info;
        }

        public async Task<int> CreateUser(CreateUserDto user)
        {
            var salt = PasswordGenerator.GenerateSalt();
            var passHash = PasswordGenerator.GeneratePasswordHash(user.Password, salt);

            _dbContext.Add(new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = passHash,
                Salt = salt
            });

            await _dbContext.SaveChangesAsync();

            var createdUser = _dbContext.Users
                .Where(dbUser => dbUser.Email == user.Email)
                .FirstOrDefault() ?? 
                throw new Exception("Failed to create user");

            return createdUser.Id;
        }
    }
}
