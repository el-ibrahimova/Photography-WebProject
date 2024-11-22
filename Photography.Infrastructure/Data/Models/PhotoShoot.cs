using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    using static Common.EntityConstants.PhotoShoot;

    [Comment("PhotoShoot")]
    public class PhotoShoot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("PhotoShoot identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("PhotoShoot Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("Image URL for first photo")]
        public string ImageUrl1 { get; set; } = null!;

        [MaxLength(ImageUrlMaxLength)]
        [Comment("Image URL for second photo")]
        public string? ImageUrl2 { get; set; }
      
        [MaxLength(ImageUrlMaxLength)]
        [Comment("Image URL for third photo")]
        public string? ImageUrl3 { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Photo shoot description")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Is photo shoot deleted")]
        public bool IsDeleted { get; set; }

        [Required]
        [Comment("Date of PhotoShoot creation")]
        public DateTime CreatedAt { get; set; }

        public ICollection<PhotoShootParticipant> Participants { get; set; } = new HashSet<PhotoShootParticipant>();
    }
}
