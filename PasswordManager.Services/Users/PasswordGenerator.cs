using System.Security.Cryptography;
using System.Text;

namespace PasswordManager.Services.Users
{
    internal static class PasswordGenerator
    {
        internal static string GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }

        internal static string GeneratePasswordHash(string password, string salt)
        {
            using var sha256Encoder = SHA256.Create() ?? 
                throw new Exception("Could not create SHA256 encoder");

            var hash = sha256Encoder.ComputeHash(Encoding.UTF8.GetBytes($"{password}{salt}")) ??
                throw new Exception("Could not create the hash");

            return Encoding.UTF8.GetString(hash);
        }
    }
}
