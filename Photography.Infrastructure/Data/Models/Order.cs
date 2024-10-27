using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Photography.Infrastructure.Data.Enums;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Order")]
    public class Order
    {
        [Key]
        [Comment("Order identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("User identifier")]
        public Guid UserId { get; set; }

        public User User { get; set; }

        [Required]
        [Comment("Offer identifier")]
        public int OfferId { get; set; }

        public Offer Offer { get; set; }

        
        public Status Status { get; set; }

        public DateTime OrderDate { get; set; }

        [MaxLength(Common.EntityConstants.OrderEntity.NoteMaxLength)]
        public string? Note { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<OrderPhoto> OrderPhotos { get; set; } = new HashSet<OrderPhoto>();
    }
}
