using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PasswordManager.Data;
using PasswordManager.Data.Options;
using PasswordManager.Services.AuthToken;
using PasswordManager.Services.Options;
using PasswordManager.Services.Password;
using PasswordManager.Services.Users;
using System.Text;

namespace PasswordManager.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add options to the container
            builder.Services.Configure<TokenAuthenticationOptions>
            (
                builder.Configuration.GetSection(TokenAuthenticationOptions.SectionName)
            );

            // Add services to the container.
            builder.Services.AddScoped<IAuthTokenService, AuthTokenService>();
            builder.Services.AddScoped<IUsersService, UsersService>();
            builder.Services.AddScoped<IPasswordGeneratorService, PasswordGeneratorService>();

            // Add db context to the container
            builder.Services.AddDbContext<PasswordManagerDbContext>(dbBuilder =>
            {
                var options = builder.Configuration.GetSection(DbOptions.SectionName).Get<DbOptions>() ??
                    throw new Exception("Could not load DbOptions");
                dbBuilder.UseSqlite($"Data Source={options.DbPath}");
            });

            // Add authentication scheme
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var configOptions = builder.Configuration.GetSection(TokenAuthenticationOptions.SectionName)
                .Get<TokenAuthenticationOptions>() ??
                    throw new Exception("Could not load authentication options");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configOptions.Issuer,
                    ValidAudience = configOptions.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configOptions.Key))
                };
            });


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Add swagger authentication scheme
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Password Manager", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}