namespace PasswordManager.Services.AuthToken.Dto
{
    public class UserAuthDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
