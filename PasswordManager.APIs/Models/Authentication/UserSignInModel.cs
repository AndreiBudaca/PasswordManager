using System.ComponentModel.DataAnnotations;

namespace PasswordManager.APIs.Models.Authentication
{
    public class UserSignInModel
    {
        [Required]
        [MaxLength(32, ErrorMessage = "First name should be less than 32 characters")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(32, ErrorMessage = "Last name should be less than 32 characters")]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [MinLength(8, ErrorMessage = "Password should be at least 8 characters")]
        public string Password { get; set; } = string.Empty;
    }
}
