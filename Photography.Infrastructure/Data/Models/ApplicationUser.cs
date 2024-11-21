using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Photography.Infrastructure.Data.Models
{
    using static Common.EntityConstants.User;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            JoinedAt=DateTime.Now;
        }

        [MaxLength(FirstNameMaxLength)]
        [Comment("User First Name")]
        public string? FirstName { get; set; }

        [MaxLength(LastNameMaxLength)]
        [Comment("User Last Name")]
        public string? LastName { get; set; }

        [Required]
        [Comment("Date of user registration")]
        public DateTime JoinedAt { get; set; }

        public ICollection<Photo> Photos { get; set; } = new HashSet<Photo>();

        public ICollection<PhotoRating> PhotosRatings { get; set; } = new List<PhotoRating>();
    }
}
