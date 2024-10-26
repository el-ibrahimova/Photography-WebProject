using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    using static Common.EntityConstants.UserEntity;

    public class User : IdentityUser
    {
        //public User()
        //{
        //    this.Id = Guid.NewGuid();
        //}

        [Key]
        [Comment("User identifier")]
        public string Id { get; set; } = null!;

        [MaxLength(FirstNameMaxLength)]
        [Comment("User First Name")]
        public string? FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        [Comment("User Last Name")]
        public string? LastName { get; set; }

        [Required]
        [Comment("Date of user registration")]
        public DateTime JoinedAt { get; set; }

        public IEnumerable<Photo> Photos { get; set; } = new HashSet<Photo>();

    }
}
