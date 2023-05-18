using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Data;
using PharmacyManagementSystem.DTO;
using PharmacyManagementSystem.Interface;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Repository
{
    public class OrderRepository: IOrder
    {
        private readonly PharmacyManagementSystemContext _context;

        public OrderRepository(PharmacyManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAllOrder()
        {
            try
            {
                var orders = await _context.Orders.ToListAsync();
                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving orders.", ex);
            }
        }

        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                return order;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the order.", ex);
            }
        }

        public async Task<Order> PostOrder(OrderDto order)
        {
            Order addedOrder=new Order();
            
           

            addedOrder.Total = order.Total;
            addedOrder.UserId = order.UserId;
            addedOrder.pickupDate = order.pickupDate;
            _context.Orders.Add(addedOrder);

            await _context.SaveChangesAsync();

            return addedOrder;
        }

        public async Task<bool> PutOrderById(int id, OrderDto order)
        {
            try
            {
                var existingOrder = await _context.Orders.FindAsync(id);
                if (existingOrder == null)
                    return false;

                existingOrder.Total = order.Total;
                existingOrder.UserId = order.UserId;
                existingOrder.pickupDate = order.pickupDate;


                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the order.", ex);
            }
        }

        public async Task<string> DeleteOrderById(int id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null)
                    return "Couldn't find the order";

                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return "Order deleted successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the order.", ex);
            }
        }
    }
}
