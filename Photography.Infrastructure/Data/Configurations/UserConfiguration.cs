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
            builder.Property(u => u.IsDeleted)
                .HasDefaultValue(false);
           
            builder.HasData(SeedUsers());
        }

        private IEnumerable<ApplicationUser> SeedUsers()
        {
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
                
            ApplicationUser clientUserOne = new ApplicationUser()
            {
                Id = Guid.Parse("58D5D0E4-2BD2-477D-B94C-FF91EC025846"),
                UserName = "ClientOne",
                NormalizedUserName = "CLIENTONE",
                Email = "client_one@gmail.com",
                NormalizedEmail = "CLIENT_ONE@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                JoinedAt = DateTime.Now
            };

            ApplicationUser clientUserTwo = new ApplicationUser()
            {
                Id = Guid.Parse("33386302-4EB2-4A2B-925C-819C1B92CC4D"),
                UserName = "ClientTwo",
                NormalizedUserName = "CLIENTTWO",
                Email = "client_two@gmail.com",
                NormalizedEmail = "CLIENT_TWO@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                JoinedAt = DateTime.Now,
            };

            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = Guid.Parse("0CEA6E1C-0655-4C21-A14B-5B5932332FFD"),
                UserName = "Admin",
                NormalizedUserName = "АDMIN",
                Email = "admin@photography.com",
                NormalizedEmail = "ADMIN@PHOTOGRAPHY.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                JoinedAt = DateTime.Now,
            };

            ApplicationUser photographerUser = new ApplicationUser()
            {
                Id = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841"),
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
