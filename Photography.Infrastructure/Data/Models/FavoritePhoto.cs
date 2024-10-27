using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Favorite photo")]
    public class FavoritePhoto
    {
        [Required]
        [Comment("User identifier")]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        [Comment("Photo identifier")]
        public int PhotoId { get; set; }

        [ForeignKey(nameof(PhotoId))]
        public Photo Photo { get; set; } = null!;
    }
}
