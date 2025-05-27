using LegoCarStoreEF.Models;
using Microsoft.EntityFrameworkCore;

namespace LegoCarStoreEF.Data
{
    public class LegoCarContext : DbContext
    {
        public DbSet<LegoCar> Cars { get; set; }

        public LegoCarContext(DbContextOptions<LegoCarContext> options) : base(options)
        {
            Database.EnsureCreated(); 
        }
    }
}