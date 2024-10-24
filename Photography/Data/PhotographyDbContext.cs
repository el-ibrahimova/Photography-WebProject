using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Photography.Data
{
    public class PhotographyDbContext : IdentityDbContext
    {
        public PhotographyDbContext(DbContextOptions<PhotographyDbContext> options)
            : base(options)
        {
        }
    }
}
