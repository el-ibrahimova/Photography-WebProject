namespace Photography.Core.ViewModels.Order
{
    public class OrderListViewModel
    {
       public string OrderId { get; set; } = null!; 
       
       public string PhotoId { get; set; } = null!;
       public string ImageUrl { get; set; } = null!;
        

        public ICollection<OfferViewModel> Offers { get; set; }= new HashSet<OfferViewModel>();
        public string OfferId { get; set; } = null!;

        public int Count { get; set; } 

    }
}
