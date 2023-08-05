
using Microsoft.EntityFrameworkCore;
using PasswordManager.Data;
using PasswordManager.Data.Options;

namespace PasswordManager.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add options to the container

            // Add services to the container.

            builder.Services.AddDbContext<PasswordManagerDbContext>(dbBuilder =>
            {
                var options = builder.Configuration.GetSection(DbOptions.SectionName).Get<DbOptions>() ??
                    throw new Exception("Could not load DbOptions");
                dbBuilder.UseSqlite($"Data Source={options.DbPath};Password={options.DbPassword}");
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}