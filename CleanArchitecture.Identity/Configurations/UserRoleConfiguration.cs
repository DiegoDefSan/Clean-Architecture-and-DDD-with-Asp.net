using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "9e55d15f-b66c-4fc3-80d0-0446834b4d83",
                    UserId = "c55bd502-c668-41e2-a125-204cf9ab3eda"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "6d8dde7f-2af4-44af-9fa2-9f4dccf17a3b",
                    UserId = "49d34870-0357-4731-b9e4-ef53fe0f181e"
                }
            );
        }
    }
}
