using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Favorite photo")]
    public class FavoritePhoto
    {
        [Required]
        [Comment("User identifier")]
        public Guid UserId { get; set; } 

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Photo identifier")]
        public Guid PhotoId { get; set; }

        [ForeignKey(nameof(PhotoId))]
        public Photo Photo { get; set; } = null!;
    }
}
