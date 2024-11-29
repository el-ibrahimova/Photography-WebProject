using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Photography.Infrastructure.Data.Models;

namespace Photography.Infrastructure.Data.Configurations
{
    public class PhotoShootParticipantConfiguration:IEntityTypeConfiguration<PhotoShootParticipant>
    {
        public void Configure(EntityTypeBuilder<PhotoShootParticipant> builder)
        {
            builder.HasKey(pp => new { pp.PhotoShootId, pp.UserId });

            builder.HasOne(pp => pp.PhotoShoot).WithMany(pp => pp.Participants).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(pp => pp.User).WithMany(pp => pp.Participants).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
