namespace Photography.Core.ViewModels.Order
{
    public class OfferViewModel
    {
        public string Id { get; set; } = null!;

      
        public string Name { get; set; } = null!;

        public string? Description { get; set; }
        
        public decimal Price { get; set; }
    }
}
