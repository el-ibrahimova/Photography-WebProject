using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Infrastructure.Data.Models
{
    using static Common.EntityConstants.PhotoEntity;

    [Comment("Photo information")]
    public class Photo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Photo identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(TagUserMaxLength)]
        [Comment("Tag user")]
        public string? TagUser { get; set; }

        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the photo")]
        public string? Description { get; set; }

        [Comment("Rating of the photo")]
        public int Rating { get; set; }

        [Required]
        [Comment("Date of photo uploading")]
        public DateTime UploadedAt { get; set; }
        
        [Comment("Date of photo uploading")]
        public DateTime? DeletedAt { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("Photo URL")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Comment("Is the photo deleted or not")]
        public bool IsDeleted { get; set; }


        [Required]
        [Comment("Is the photo private ot public")]
        public bool IsPrivate { get; set; }

        [Comment("Is the user owner of photo")]
        public Guid? UserOwnerId { get; set; }

        [ForeignKey(nameof(UserOwnerId))]
        public ApplicationUser? Owner { get; set; }


        public ICollection<FavoritePhoto> FavoritePhotos { get; set; } = new HashSet<FavoritePhoto>();

        public ICollection<OrderPhoto> OrderPhotos { get; set; } = new HashSet<OrderPhoto>();

        public ICollection<PhotoCategory> PhotosCategories { get; set; } = new HashSet<PhotoCategory>();
        public ICollection<PhotoRating> PhotosRatings { get; set; } = new HashSet<PhotoRating>();
    }
}
