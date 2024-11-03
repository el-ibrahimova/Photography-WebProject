using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Photography.Common.EntityConstants.OfferEntity;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Offers")]
    public class Offer
    {
        [Key]
        [Comment("Offer identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Offer name")]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Offer type identifier")]
        public Guid OfferTypeId { get; set; }

        public OfferType OfferType { get; set; } = null!;
    }
}
