using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShopper.Shipping.BusinessLayer.Abstract;
using EShopper.Shipping.DataAccessLayer.Abstract;
using EShopper.Shipping.EntityLayer.Domain;

namespace EShopper.Shipping.BusinessLayer.Managers
{
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _CargoCustomerDal;

        public CargoCustomerManager(ICargoCustomerDal CargoCustomerDal)
        {
            _CargoCustomerDal = CargoCustomerDal;
        }

        public async Task TAddAsync(CargoCustomer entity)
        {
            await _CargoCustomerDal.InsertAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _CargoCustomerDal.DeleteAsync(id);
        }

        public async Task<List<CargoCustomer>> TGetAllAsync()
        {
            return await _CargoCustomerDal.GetAllAsync();
        }

        public async Task<CargoCustomer> TGetByIdAsync(int id)
        {
            return await _CargoCustomerDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(CargoCustomer entity)
        {
            await _CargoCustomerDal.UpdateAsync(entity);
        }
    }
}
