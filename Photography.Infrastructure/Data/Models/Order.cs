using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Photography.Infrastructure.Data.Enums;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Order identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Comment("User identifier")]
        public Guid UserId { get; set; } 

        public ApplicationUser User { get; set; } = null!;

        [Required]
        [Comment("Offer identifier")]
        public Guid OfferId { get; set; }

        public Offer Offer { get; set; } = null!;

        
        public Status Status { get; set; }

        public DateTime OrderDate { get; set; }

        [MaxLength(Common.EntityConstants.OrderEntity.NoteMaxLength)]
        public string? Note { get; set; }

        public decimal TotalAmount { get; set; }

        public ICollection<OrderPhoto> OrderPhotos { get; set; } = new HashSet<OrderPhoto>();
    }
}
