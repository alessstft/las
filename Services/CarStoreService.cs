using LegoCarStoreEF.Models;
using LegoCarStoreEF.Data;
using Microsoft.EntityFrameworkCore;

namespace LegoCarStoreEF.Services
{
    public class CarStoreService
    {
        private readonly LegoCarContext _context;

        public CarStoreService(LegoCarContext context)
        {
            _context = context;
        }

        public async Task<List<LegoCar>> GetAllCarsAsync() => await _context.Cars.ToListAsync();

        public async Task AddCarAsync(string name, decimal price)
        {
            await _context.Cars.AddAsync(new LegoCar { Name = name, Price = price });
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveCarAsync(int id)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
            if (car == null) return false;
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.Profile).ToListAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByUserAsync(int userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Items)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }
    }
}
