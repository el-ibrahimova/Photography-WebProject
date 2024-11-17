using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Categories of photos")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Category identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(Common.EntityConstants.Category.NameMaxLength)]
        [Comment("Name of the category")]
        public string Name { get; set; } = null!;

        public ICollection<PhotoCategory> PhotosCategories { get; set; } = new HashSet<PhotoCategory>();
    }
}
