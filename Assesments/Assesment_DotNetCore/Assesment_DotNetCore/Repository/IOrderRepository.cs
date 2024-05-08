using Assesment_DotNetCore.Models;
using System.Collections.Generic;

namespace Assesment_DotNetCore.Repository
  
{
    public interface IOrderRepository
    {
        Task PlaceOrder(Order order);
        Task<Order> GetOrderDetails(int orderId);
        //Task<decimal> GetBill(int orderId);
        Task<List<Order>> GetOrdersByDate(DateTime startDate, DateTime endDate);
        // Task<Customer> GetCustomerWithHighestOrder();
    }
}