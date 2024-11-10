using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Photography.Infrastructure.Data.Models
{
    [Comment("Order photo")]
    public class OrderPhoto
    {
        [Comment("Photo identifier")]
        public Guid PhotoId { get; set; }
       
        [ForeignKey(nameof(PhotoId))]
        public Photo Photo { get; set; } = null!;


        [Comment("Order identifier")]
        public Guid OrderId { get; set; }
       
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        public Guid OfferId { get; set; }

        [ForeignKey(nameof(OfferId))] 
        public Offer Offer { get; set; } = null!;


        [Comment("Count of ordered photos")]
        public int Count { get; set; }
    }
}
