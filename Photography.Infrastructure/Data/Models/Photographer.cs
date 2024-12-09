using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    using static Common.EntityConstants.Photographer;

    [Comment("Photographer")]
    public class Photographer
    {
        [Key]
        [Comment("Photographer identifier")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(BrandNameMaxLength)]
        [Comment("Brand name of the photographer")]
        public string BrandName { get; set; } = null!;

        [Comment("Photographer user identifier")]
        public Guid UserId { get; set; }
       
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
        public ICollection<PhotoShoot> PhotoShoots { get; set; } = new HashSet<PhotoShoot>();
        public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();
    }
}
