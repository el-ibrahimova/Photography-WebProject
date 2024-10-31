﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Rating for photo")]
    public class PhotoRating
    {
        [Key]
        [Comment("Rate identifier")]
        public int Id { get; set; }

        [Comment("Photo identifier")]
        public Guid PhotoId { get; set; }

        public Photo Photo { get; set; } = null!;

        [Comment("User identifier")]
        public Guid UserId { get; set; }

        public User User { get; set; } = null!;

        [Comment("Rate")]
        public int Rating { get; set; }
    }
}