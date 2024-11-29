using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;
using static Photography.Common.EntityConstants;

namespace Photography.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.JoinedAt)
                .HasDefaultValue(DateTime.Now);
           
            builder.HasData(SeedUsers());
        }

        private IEnumerable<ApplicationUser> SeedUsers()
        {
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
                
            ApplicationUser clientUserOne = new ApplicationUser()
            {
                Id = Guid.Parse("E8E05209-B1CE-43E9-898B-885DD3FFC422"),
                UserName = "ClientOne",
                NormalizedUserName = "CLIENTONE",
                Email = "client_one@gmail.com",
                NormalizedEmail = "CLIENT_ONE@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                JoinedAt = DateTime.Now,
            };

            ApplicationUser clientUserTwo = new ApplicationUser()
            {
                Id = Guid.Parse("DEBACEA0-5C7B-461D-A2FB-5AF5284A7F9A"),
                UserName = "ClientTwo",
                NormalizedUserName = "CLIENTTWO",
                Email = "client_two@gmail.com",
                NormalizedEmail = "CLIENT_TWO@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                JoinedAt = DateTime.Now,
            };

            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = Guid.Parse("A18BB94E-1A7C-4D44-B80C-FC984ACF1B0D"),
                UserName = "Admin",
                NormalizedUserName = "АDMIN",
                Email = "admin@photography.com",
                NormalizedEmail = "ADMIN@PHOTOGRAPHY.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                JoinedAt = DateTime.Now,
            };

            ApplicationUser photographerUser = new ApplicationUser()
            {
                Id = Guid.Parse("04C70E70-5CF9-4E8A-A694-5C7C8D730A8F"),
                UserName = "Photographer",
                NormalizedUserName = "PHOTOGRAPHER",
                Email = "photographer@gmail.com",
                NormalizedEmail = "PHOTOGRAPHER@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                JoinedAt = DateTime.Now,
            };

            clientUserOne.PasswordHash = passwordHasher.HashPassword(clientUserOne, "Client123ONE");
            clientUserTwo.PasswordHash = passwordHasher.HashPassword(clientUserTwo, "Client123TWO");
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "ADMIN123admin");
            photographerUser.PasswordHash = passwordHasher.HashPassword(photographerUser, "Photographer123PH");

            List<ApplicationUser> users = new List<ApplicationUser>() { clientUserOne,clientUserTwo, adminUser, photographerUser };

            return users;
        }
    }
}
