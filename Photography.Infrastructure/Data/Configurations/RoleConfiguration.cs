using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Photography.Infrastructure.Data.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
        {
            builder.HasData(SeedRoles());
        }

        private IEnumerable<IdentityRole<Guid>> SeedRoles()
        {
            IEnumerable<IdentityRole<Guid>> roles = new List<IdentityRole<Guid>>()
            {
                new IdentityRole<Guid>()
                {   Id = Guid.Parse("8246F96F-BD49-4DB2-69AE-08DD176D0F38"),
                    Name = "User",
                    NormalizedName = "USER"
                },


                new IdentityRole < Guid >()
                    { Id = Guid.Parse("34282161-754B-4C2A-2EC6-08DD12303248"),
                      Name = "Admin",
                      NormalizedName = "ADMIN"
                    }
            };
            return roles;

        }
    }
}
