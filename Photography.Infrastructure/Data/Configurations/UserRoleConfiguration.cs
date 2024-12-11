using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Photography.Infrastructure.Data.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });
            builder.HasData(SeedUserRoles());
        }

        private IEnumerable<IdentityUserRole<Guid>> SeedUserRoles()
        {
            IEnumerable<IdentityUserRole<Guid>> usersRoles = new List<IdentityUserRole<Guid>>()
            {
                //  photographer
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("95D458A7-115A-4DB5-9319-809C7763D841"),
                    RoleId = Guid.Parse("8246F96F-BD49-4DB2-69AE-08DD176D0F38")
                },
              
                //  photographer Miki
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("5DBF7705-08FA-472D-BF9C-1FAEAA220749"),
                    RoleId = Guid.Parse("8246F96F-BD49-4DB2-69AE-08DD176D0F38")
                },

                //  clientOne
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("58D5D0E4-2BD2-477D-B94C-FF91EC025846"),
                    RoleId = Guid.Parse("8246F96F-BD49-4DB2-69AE-08DD176D0F38")
                },

                //  clientTwo
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse("33386302-4EB2-4A2B-925C-819C1B92CC4D"),
                    RoleId = Guid.Parse("8246F96F-BD49-4DB2-69AE-08DD176D0F38")
                },
            };

            return usersRoles;
        }
    }
}
