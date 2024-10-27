using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class CommentConfiguration:IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(p => p.IsDeleted)
                .HasDefaultValue(false);
        }
    }
}
