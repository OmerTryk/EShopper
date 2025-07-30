using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopper.Shipping.DataAccessLayer.Abstract;
using EShopper.Shipping.DataAccessLayer.Data;
using EShopper.Shipping.DataAccessLayer.Repositories;
using EShopper.Shipping.EntityLayer.Domain;

namespace EShopper.Shipping.DataAccessLayer.EntityFramework
{
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        public EfCargoCompanyDal(CargoContext context) : base(context)
        {
        }
    }
}
