using project.Model;
using Microsoft.EntityFrameworkCore;
using project.Model;

namespace project.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Salesman> Salesmens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                // Specify precision for decimal properties
                entity.Property(e => e.SellingPrice).HasPrecision(18, 2);
                entity.Property(e => e.PurchasingPrice).HasPrecision(18, 2);
            });
            modelBuilder.Entity<Salesman>(entity =>
            {
                entity.Property(e => e.Salary).HasPrecision(18, 2); // Set precision for Salary
                entity.Property(e => e.Commission).HasPrecision(18, 2); // Set precision for Commission
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
