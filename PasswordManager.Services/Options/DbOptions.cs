namespace PasswordManager.Data.Options
{
    public class DbOptions
    {
        public string DbPath { get; set; } = string.Empty;
        public string DbPassword { get; set; } = string.Empty;

        public static string SectionName { get; set; } = "DbOptions";
    }
}
