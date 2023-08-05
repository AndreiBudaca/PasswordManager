using Microsoft.EntityFrameworkCore;
using PasswordManager.Data.Entities;
namespace PasswordManager.Data
{
    public class PasswordManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public PasswordManagerDbContext() : base() { }

        public PasswordManagerDbContext(DbContextOptions<PasswordManagerDbContext> options)
         : base(options) { }
    }
}