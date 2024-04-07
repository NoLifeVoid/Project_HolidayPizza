using Microsoft.EntityFrameworkCore;

namespace HolidayPizza
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define DbSet properties for your database tables
        public DbSet<Pizza> Pizza { get; set; } // or any other appropriate name
        public DbSet<Cheese> Cheese { get; set; }
        public DbSet<Sauce> Sauce { get; set; }
        public DbSet<Dough> Dough { get; set; }
        public DbSet<Topping>Topping { get; set; }

         public DbSet<PizzaTopping>PizzaTopping { get; set; }
    

    }

}
