﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    using static Common.EntityConstants.UserEntity;

    public class User : IdentityUser<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

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

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
