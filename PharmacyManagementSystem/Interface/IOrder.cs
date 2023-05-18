using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Interface
{
    public interface IOrder
    {
        Task<List<Order>> GetAllOrder();
        Task<Order> GetOrderById(int id);
        Task<Order> PostOrder(OrderDto drug);
        Task<bool> PutOrderById(int id, OrderDto drug);
        Task<string> DeleteOrderById(int id);
    }
}
