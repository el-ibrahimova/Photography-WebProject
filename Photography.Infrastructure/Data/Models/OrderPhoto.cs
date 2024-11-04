using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Order photo")]
    public class OrderPhoto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Order photo identifier")]
        public Guid OrderPhotoId { get; set; } = Guid.NewGuid();

        [Comment("Photo identifier")]
        public Guid PhotoId { get; set; }
        public Photo Photo { get; set; } = null!;

        [Comment("Order identifier")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public int Count { get; set; }
    }
}
