using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Photo comments")]
    public class Comment
    {
        [Key]
        [Comment("Comment identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User identifier")]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        [Comment("Name of the user")]
        public string Username { get; set; } = null!;

        [Required]
        [Comment("Photo identifier")]
        public int PhotoId { get; set; }

        public Photo Photo { get; set; } = null!;

        [Required]
        [Comment("Date of post")]
        public DateTime CreatedOn { get; set; }

        [Comment("Is the comment deleted")]
        public bool IsDeleted { get; set; }
    }
}
