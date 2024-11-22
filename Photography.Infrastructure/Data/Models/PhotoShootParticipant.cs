using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("PhotoShoot Participant")]
    public class PhotoShootParticipant
    {
        [Key]
        [Comment("Identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("PhotoShoot identifier")]
        public Guid PhotoShootId { get; set; }

        [ForeignKey(nameof(PhotoShootId))]
        public PhotoShoot PhotoShoot { get; set; } = null!;

        [Comment("User identifier")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}
