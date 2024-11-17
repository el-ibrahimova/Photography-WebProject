using Photography.Core.ViewModels.Order;

namespace Photography.Core.Interfaces
{
    public interface IOrderService:IBaseService
    {
        IEnumerable<OrderListViewModel> GetOrderForUserAsync(string userId);
        Task<bool> RemoveOrder(OrderListViewModel model);
        Task <bool> AcceptOrder(OrderListViewModel model);
    }
}
