using PasswordManager.APIs.Models.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

namespace PasswordManager.APIs.Models.Account
{
    public class PasswordGenerateOptionsModel
    {
        [Required(ErrorMessage = "Please provide a password length")]
        [Value(4, 32, ErrorMessage = "Password length should be between 4 and 32 characters")]
        public int Length { get; set; }
        public bool UseLowerAlpha { get; set; }
        public bool UseUpperAlpha { get; set; }
        public bool UseNumeric { get; set; }
        public bool UseSpecial { get; set; }
    }
}
