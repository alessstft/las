using LegoCarStoreEF.Models;
using LegoCarStoreEF.Services;

namespace LegoCarStoreEF.Application
{
    public class CarStoreController
    {
        private readonly CarStoreService _service;

        public CarStoreController(CarStoreService service)
        {
            _service = service;
        }

        public Task<List<LegoCar>> GetAllCarsAsync() => _service.GetAllCarsAsync();
        public Task AddCarAsync(string name, decimal price) => _service.AddCarAsync(name, price);
        public Task<bool> RemoveCarAsync(int id) => _service.RemoveCarAsync(id);

        public Task<List<User>> GetAllUsersAsync() => _service.GetAllUsersAsync();
        public Task<List<Category>> GetAllCategoriesAsync() => _service.GetAllCategoriesAsync();
        public Task<List<Tag>> GetAllTagsAsync() => _service.GetAllTagsAsync();
        public Task<List<Order>> GetOrdersByUserAsync(int userId) => _service.GetOrdersByUserAsync(userId);
        public Task<List<Product>> GetAllProductsAsync() => _service.GetAllProductsAsync();
    }
}
