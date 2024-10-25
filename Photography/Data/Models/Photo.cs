using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Photography.Data.Models
{
    using static Common.EntityConstants.PhotoEntity;

    [Comment("Photo information")]
    public class Photo
    {
        [Key]
        [Comment("Photo identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("Title of the photo")]
        public string Title { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        [Comment("Description of the photo")]
        public string? Description { get; set; }

        [Required]
        [Comment("Date of photo uploading")]
        public DateTime UploadedAt { get; set; }

        [Required]
        [MaxLength(ImageUrlMaxLength)]
        [Comment("Photo URL")]
        public string ImageUrl { get; set; } = null!;
    }
}
