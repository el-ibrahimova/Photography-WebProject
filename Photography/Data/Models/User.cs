using Microsoft.AspNetCore.Identity;

namespace Photography.Data
{
    public class User : IdentityUser
    {
        //public User()
        //{
        //    this.Id = Guid.NewGuid();
        //}

        public string Id { get; set; } = null!;

        public string? FirstName { get; set; }
        public string? LastName { get; set;}



    }
}
