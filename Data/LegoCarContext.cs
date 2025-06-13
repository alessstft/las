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
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }

    }
}