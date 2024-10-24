using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Photography.Common.EntityConstants;

namespace Photography.Data.Models
{
    [Comment("Photo information")]
    public class Photo
    {
        [Key]
        [Comment("Photo identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(PhotoTitleMaxLength)]
        [Comment("Title of the photo")]
        public string Title { get; set; } = null!;

        [MaxLength(PhotoDescriptionMaxLength)]
        [Comment("Description of the photo")]
        public string? Description { get; set; }
    }
}
