using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Photo comments")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Comment identifier")] 
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("User identifier")]
        public Guid UserId { get; set; } 
        public ApplicationUser User { get; set; } = null!;

        [Comment("Name of the user")]
        public string Username { get; set; } = null!;

        [Required]
        [Comment("Photo identifier")]
        public Guid PhotoId { get; set; }

        public Photo Photo { get; set; } = null!;

        [Required]
        [Comment("Date of post")]
        public DateTime CreatedOn { get; set; }

        [Comment("Is the comment deleted")]
        public bool IsDeleted { get; set; }
    }
}
