using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Photo Categories")]
    public class PhotoCategory
    {
        [Comment("Photo identifier")]
        public Guid PhotoId { get; set; } 

        [ForeignKey(nameof(PhotoId))]
        public Photo Photo { get; set; } = null!;

        [Comment("Category identifier")]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
    }
}
