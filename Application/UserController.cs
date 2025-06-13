using Services;
using Models;
using System.Collections.Generic;

namespace Application
{
	public class UserController
	{
		private readonly CarStoreService _service;

		public UserController(CarStoreService service)
		{
			_service = service;
		}

		public List<User> GetAllUsers() => _service.GetAllUsers();
		public void AddUser(User user) => _service.AddUser(user);
		public Profile GetProfileByUserId(int userId) => _service.GetProfileByUserId(userId);
	}
}
