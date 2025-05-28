using LegoCarStoreEF.Models;
using LegoCarStoreEF.Data;

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
    }
}