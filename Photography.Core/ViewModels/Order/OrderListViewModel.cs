using Photography.Infrastructure.Data.Models;

namespace Photography.Core.ViewModels.Order
{
    public class OrderListViewModel
    {
        public string PhotoId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string OrderId { get; set; } = null!;

        public ICollection<Offer> Offers { get; set; }= new HashSet<Offer>();
        public string OfferId { get; set; } = null!;

    }
}
