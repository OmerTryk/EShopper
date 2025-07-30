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
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _CargoOperationDal;

        public CargoOperationManager(ICargoOperationDal CargoOperationDal)
        {
            _CargoOperationDal = CargoOperationDal;
        }

        public async Task TAddAsync(CargoOperation entity)
        {
            await _CargoOperationDal.InsertAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _CargoOperationDal.DeleteAsync(id);
        }

        public async Task<List<CargoOperation>> TGetAllAsync()
        {
            return await _CargoOperationDal.GetAllAsync();
        }

        public async Task<CargoOperation> TGetByIdAsync(int id)
        {
            return await _CargoOperationDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(CargoOperation entity)
        {
            await _CargoOperationDal.UpdateAsync(entity);
        }
    }
}
