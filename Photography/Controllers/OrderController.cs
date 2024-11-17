using Microsoft.AspNetCore.Mvc;
using Photography.Core.Interfaces;
using Photography.Core.ViewModels.Order;
using Photography.Infrastructure.Data;

namespace Photography.Controllers
{
    public class OrderController : BaseController
    {
        private readonly PhotographyDbContext context;
        private readonly IOrderService orderService;


        public OrderController(IOrderService _orderService, PhotographyDbContext data)
        {
            orderService = _orderService;
            context = data;
        }

        [HttpGet]
        public async Task <IActionResult> OrderList()
        {
            return View();
        }
    }
}