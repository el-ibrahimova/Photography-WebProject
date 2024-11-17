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
        :base(data)
        {
            context = data;
        }

        public async Task<ICollection<OrderListViewModel>> GetOrdersWithOffers(string userId)
        {

            return await context.OrderPhotos
                  .Include(op => op.Photo)
                  .Include(o => o.Order)
                  .Include(o => o.Offer)
                  .Where(o => o.Order.UserId.ToString() == userId)
                  .AsNoTracking()
                  .Select(o => new OrderListViewModel
                  {
                      OrderId = o.OrderId.ToString(),
                      ImageUrl = o.Photo.ImageUrl,
                      PhotoId = o.PhotoId.ToString(),
                      Count = o.Count,
                  }).ToListAsync();

        }
        public async Task<ICollection<OfferViewModel>> GetOffersAsync()
        {
            return await context.Offers
                .AsNoTracking()
                .Select(c => new OfferViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Price = c.Price
                })
                .ToListAsync();
        }
    }
}
