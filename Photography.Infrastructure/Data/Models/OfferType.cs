using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static Photography.Common.EntityConstants.OfferTypeEntity;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Type of offer")]
    public class OfferType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Type identifier")]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("Type description")]
        public string? Description { get; set; }

        public decimal Price { get; set; }
    }
}
