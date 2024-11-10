using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Order;
using Photography.Core.ViewModels.Photo;
using Photography.Data;

namespace Photography.Core.Services
{
    public class OrderService:BaseService, IOrderService
    {
        private readonly PhotographyDbContext context;

        public OrderService(PhotographyDbContext data)
        {
            context = data;
        }


        public Task<ICollection<OrderListViewModel>> GetOrderListAsync(string userId)
        {
            return null;
        }
    }
}
