using Microsoft.EntityFrameworkCore;

namespace PasswordManager.Data.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
    }
}
