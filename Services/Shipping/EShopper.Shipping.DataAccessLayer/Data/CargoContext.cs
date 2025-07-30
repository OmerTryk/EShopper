using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopper.Shipping.EntityLayer.Domain;
using Microsoft.EntityFrameworkCore;

namespace EShopper.Shipping.DataAccessLayer.Data
{
    public class CargoContext : DbContext
    {
        public CargoContext(DbContextOptions<CargoContext> options) : base(options)
        {
        }

        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }

    }
}
