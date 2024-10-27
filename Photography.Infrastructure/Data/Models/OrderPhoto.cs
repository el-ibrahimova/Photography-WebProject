using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Order photo")]
    public class OrderPhoto
    {
        [Key]
        [Comment("Order photo identifier")]
        public int OrderPhotoId { get; set; }

        [Comment("Photo identifier")]
        public int PhotoId { get; set; }
        public Photo Photo { get; set; } = null!;

        [Comment("Order identifier")]
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int Count { get; set; }
    }
}
