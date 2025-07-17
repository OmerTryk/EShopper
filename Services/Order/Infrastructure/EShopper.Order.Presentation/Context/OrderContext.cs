using EShopper.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopper.Order.Presentation.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=OMERTRYK;Database=EShopperOrderDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Domain.Entities.Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
    }
}
