using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Models;

namespace PharmacyManagementSystem.Data
{
    public class PharmacyManagementSystemContext:DbContext
    {
        public PharmacyManagementSystemContext(DbContextOptions<PharmacyManagementSystemContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Drug>? Drugs { get; set; }
        public DbSet<Supplier>? Suppliers { get; set; }
        public DbSet<Order>? Orders { get; set; }

        public DbSet<OrderDetail>? OrderDetails { get; set; }

        public DbSet<Sale>? Sales { get; set; }
      



    }
}
