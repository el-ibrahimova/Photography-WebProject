using Photography.Core.ViewModels.Order;
using Photography.Core.ViewModels.Photo;

namespace Photography.Core.Interfaces
{
    public interface IOrderService:IBaseService
    {
        Task<ICollection<OrderListViewModel>> GetOrderListAsync(string userId);
    }
}
