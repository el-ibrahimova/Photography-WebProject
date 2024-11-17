using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static Photography.Common.EntityConstants.OfferEntity;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Offers")]
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Offer identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Offer name")]
        public string Name { get; set; } = null!;

        [Comment("Offer price")]
        public decimal Price { get; set; }
    }
}
