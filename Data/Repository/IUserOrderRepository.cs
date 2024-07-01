using MAFTLECOME.Models;
using MAFTLECOME.Models.DTOs;

namespace MAFTLECOME.Data.Repository
{
    public interface IUserOrderRepository
    {
        Task<IEnumerable<Order>> UserOrders(bool getAll = false);
        Task ChangeOrderStatus(UpdateOrderStatusModel data);
        Task TogglePaymentStatus(int orderId);
        Task DeleteOrder(int orderId);
        Task<Order?> GetOrderById(int id);
        Task<IEnumerable<OrderStatus>> GetOrderStatuses();

    }
}