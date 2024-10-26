using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Categories of photos")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(Common.EntityConstants.CategoryEntity.NameMaxLength)]
        [Comment("Name of the category")]
        public string Name { get; set; } = null!;
    }
}
