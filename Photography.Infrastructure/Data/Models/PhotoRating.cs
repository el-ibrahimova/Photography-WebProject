using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Rating for photo")]
    public class PhotoRating
    {
        [Key]
        [Comment("Rate identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Comment("Photo identifier")]
        public Guid PhotoId { get; set; }

        [ForeignKey(nameof(PhotoId))]
        public Photo Photo { get; set; } = null!;

        [Comment("User identifier")] 
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))] 
        public ApplicationUser User { get; set; } = null!;
    }
}
