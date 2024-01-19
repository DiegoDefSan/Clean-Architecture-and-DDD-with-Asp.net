using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "c55bd502-c668-41e2-a125-204cf9ab3eda",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Nombre = "Diego",
                    Apellidos = "Defilippi",
                    UserName = "DDefSan",
                    NormalizedUserName = "DDefSan",
                    PasswordHash = hasher.HashPassword(null, "Password_123"),
                    EmailConfirmed=true
                },
                new ApplicationUser
                {
                    Id = "49d34870-0357-4731-b9e4-ef53fe0f181e",
                    Email = "juanperez@localhost.com",
                    NormalizedEmail = "juanperez@localhost.com",
                    Nombre = "Juan",
                    Apellidos = "Perez",
                    UserName = "JuanPerez",
                    NormalizedUserName = "JuanPerez",
                    PasswordHash = hasher.HashPassword(null, "Password_123"),
                    EmailConfirmed = true
                }
            );
        }
    }
}
