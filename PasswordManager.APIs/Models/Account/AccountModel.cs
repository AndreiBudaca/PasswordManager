using System.ComponentModel.DataAnnotations;

namespace PasswordManager.APIs.Models.Account
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }

        [Required]
        public string Domain { get; set; } = string.Empty;
    }
}
