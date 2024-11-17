using Photography.Core.ViewModels.Order;

namespace Photography.Core.Interfaces
{
    public interface IOrderService:IBaseService
    {
        Task<ICollection<OrderListViewModel>> GetOrderListAsync(string userId);
    }
}
