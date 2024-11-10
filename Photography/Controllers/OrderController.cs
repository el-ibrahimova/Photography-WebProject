using Microsoft.AspNetCore.Mvc;
using Photography.Core.Interfaces;
using Photography.Core.Services;

namespace Photography.Controllers
{
    public class OrderController : BaseController
    {

        private readonly IOrderService orderService;


        public OrderController(IOrderService _orderService)
        {
           orderService=_orderService;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            string userId = GetUserId() ?? String.Empty;

            return View();

        }

        public IActionResult Remove()
        {
            return View();
        }

        public IActionResult AcceptOrder()
        {
            return View();
        }
    }
}
