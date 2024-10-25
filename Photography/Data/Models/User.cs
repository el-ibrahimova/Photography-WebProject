using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Photography.Data
{
    public class User : IdentityUser
    {
        //public User()
        //{
        //    this.Id = Guid.NewGuid();
        //}
        
        [Key]
        [Comment("User identifier")]
        public string Id { get; set; } = null!;

        public string? FirstName { get; set; }
        public string? LastName { get; set;}

        

        [Comment("User username")]
        public string Username { get; set; } = null!;



    }
}
