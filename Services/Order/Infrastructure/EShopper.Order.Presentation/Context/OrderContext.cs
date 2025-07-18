using EShopper.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EShopper.Order.Presentation.Context
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
    }
}
