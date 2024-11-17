using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Order;
using Photography.Infrastructure.Data;

namespace Photography.Core.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly PhotographyDbContext context;

        public OrderService(PhotographyDbContext data)
        {
            context = data;
        }

        
        public async Task<ICollection<OrderListViewModel>> GetOrderForUserAsync(string userId)
        {
            return await context.OrderPhotos
                       .Include(op => op.Photo)
                       .Include(o => o.Order)
                       .Include(o=>o.Offer)
                       .Where(o => o.Order.UserId.ToString() == userId)
                       .AsNoTracking()
                .Select(o => new OrderListViewModel
                {
                    OrderId = o.OrderId.ToString(),
                    ImageUrl = o.Photo.ImageUrl,
                    PhotoId = o.PhotoId.ToString(),
                    Offers = o.Select(offer => new OfferViewModel
                    {
                        Id = offer.Id,
                        Name = offer.Name,
                        Price = offer.Price
                    }).ToLista()
                }).ToListAsync();

                  }

        public Task<bool> RemoveOrder(OrderListViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AcceptOrder(OrderListViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
