using Photography.Core.ViewModels.Order;

namespace Photography.Core.Interfaces
{
    public interface IOrderService:IBaseService
    {
       Task <ICollection<OrderListViewModel>> GetOrdersWithOffers(string userId);
    }
}
