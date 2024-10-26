using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
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

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [Comment("Category of photo")]
        public Category Category { get; set; } = null!;

        [Comment("Is the photo deleted or not")]
        public bool IsDeleted { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
