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
                JoinedAt = DateTime.Now,
                FirstName = "Иво",
                LastName = "Пенев",
                PhoneNumber = "0889111111"
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
                FirstName = "Милена",
                LastName = "Иванова",
                PhoneNumber = "0889222222"
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
                FirstName = "Администратор",
                LastName = "Тодорова",
                PhoneNumber = "0889333333"
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
                FirstName = "Ниса",
                LastName = "Кехайова",
                PhoneNumber = "0889444444"
            };

            ApplicationUser photographerMiki = new ApplicationUser()
            {
                Id = Guid.Parse("5DBF7705-08FA-472D-BF9C-1FAEAA220749"),
                UserName = "PhotographerMiki",
                NormalizedUserName = "PHOTOGRAPHERMIKI",
                Email = "photographerMiki@gmail.com",
                NormalizedEmail = "PHOTOGRAPHERMIKI@GMAIL.COM",
                SecurityStamp = Guid.NewGuid().ToString(),
                JoinedAt = DateTime.Now,
                FirstName = "Микаел",
                LastName = "Хаджиев",
                PhoneNumber = "0889555555"
            };

            clientUserOne.PasswordHash = passwordHasher.HashPassword(clientUserOne, "Client123ONE");
            clientUserTwo.PasswordHash = passwordHasher.HashPassword(clientUserTwo, "Client123TWO");
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "ADMIN123admin");
            photographerUser.PasswordHash = passwordHasher.HashPassword(photographerUser, "Photographer123PH");
            photographerMiki.PasswordHash = passwordHasher.HashPassword(photographerMiki, "PhotographerMiki");

            List<ApplicationUser> users = new List<ApplicationUser>() { clientUserOne,clientUserTwo, adminUser, photographerUser, photographerMiki};

            return users;
        }
    }
}
