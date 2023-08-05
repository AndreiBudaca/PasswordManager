namespace PasswordManager.Services.Options
{
    public class TokenAuthenticationOptions
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpirationMinutes { get; set; }

        public static string SectionName { get; set; } = "JWT";
    }
}
