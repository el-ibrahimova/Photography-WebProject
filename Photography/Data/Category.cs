using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Photography.Data
{
    public class Category
    {
        [Key]
        [Comment("Category identification")]
        public int Id { get; set; }

        [Required]
        [MaxLength(Common.EntityConstants.CategoryNameMaxLength)]
        [Comment("Name of the category")]
        public string Name { get; set; } = null!;
    }
}
