using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Assesment_DotNetCore.Models;
using Assesment_DotNetCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Assesment_DotNetCore.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PlaceOrder()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Order order)
        {
            await _orderRepository.PlaceOrder(order);
            var updatedOrder = await _orderRepository.GetOrderDetails(order.OrderId);
            return View("PlaceOrder", updatedOrder);
        }


        [HttpGet]
        public async Task<IActionResult> orderDetails(int id)
        {
            var order = await _orderRepository.GetOrderDetails(id); // Await the async method
            return View(order);
        }


        [HttpGet]
        public async Task<IActionResult>GetOrdersByDate(DateTime startDate, DateTime endDate)
        {
            var orders = await _orderRepository.GetOrdersByDate(startDate, endDate);
            return View(orders);
        }

    }
}
