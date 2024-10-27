using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using static Photography.Common.EntityConstants.OfferTypeEntity;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Type of offer")]
    public class OfferType
    {
        [Key]
        [Comment("Type identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("Type description")]
        public string? Description { get; set; }

        public decimal Price { get; set; }
    }
}
