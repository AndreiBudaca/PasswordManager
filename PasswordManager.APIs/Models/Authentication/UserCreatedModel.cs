namespace PasswordManager.APIs.Models.Authentication
{
    public class UserCreatedModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
