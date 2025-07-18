using EShopper.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopper.Order.Presentation.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;Database=EShopperOrderDb;User Id=sa;Password=Admin123456*;TrustServerCertificate=True;");

        }

        public DbSet<Domain.Entities.Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
    }
}
