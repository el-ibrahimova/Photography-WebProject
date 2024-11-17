using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Photography.Core.Interfaces;
using Photography.Core.Services;
using Photography.Core.ViewModels.Order;
using Photography.Core.ViewModels.Photo;
using Photography.Infrastructure.Data;

namespace Photography.Controllers
{
    public class OrderController : BaseController
    {
        private readonly PhotographyDbContext context;
        private readonly IOrderService orderService;


        public OrderController(IOrderService _orderService, PhotographyDbContext data)
        {
           orderService=_orderService;
           context = data;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var orderViewModels = new List<OrderListViewModel>
            {
                new OrderListViewModel
                {
                    Offers = await GetOffersAsync()
                }
               
            };

            return View(orderViewModels);
        }


        [HttpPost]
        public async Task<IActionResult> OrderList(OrderListViewModel model)
        {
            var orderViewModels = new List<OrderListViewModel>
            {
                new OrderListViewModel 
                {
                    Offers = await GetOffersAsync()
                }

            };

            return View(orderViewModels);
        }

        public IActionResult Remove()
        {
            return View();
        }

        public IActionResult AcceptOrder()
        {
            return View();
        }

        public async Task<ICollection<OfferViewModel>> GetOffersAsync()
        {
            return await context.Offers
                .AsNoTracking()
                .Select(c => new OfferViewModel()
                {
                    Id = c.Id.ToString(),
                    Name = c.Name,
                    Description = c.Description,
                    Price = c.Price
                })
                .ToListAsync();
        }
    }
}
