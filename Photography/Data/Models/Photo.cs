using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Photography.Common.EntityConstants.PhotoEntity;

namespace Photography.Data.Models
{
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
    }
}
