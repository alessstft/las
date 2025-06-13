using Services;
using Models;
using System.Collections.Generic;

namespace Application
{
	public class OrderController
	{
		private readonly CarStoreService _service;

		public OrderController(CarStoreService service)
		{
			_service = service;
		}

		public void AddOrder(Order order) => _service.AddOrder(order);
		public void AddOrderItem(OrderItem item) => _service.AddOrderItem(item);
		public List<Order> GetOrdersByUser(int userId) => _service.GetOrdersByUser(userId);
	}
}
