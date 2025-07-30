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
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _CargoCompanyDal;

        public CargoCompanyManager(ICargoCompanyDal CargoCompanyDal)
        {
            _CargoCompanyDal = CargoCompanyDal;
        }

        public async Task TAddAsync(CargoCompany entity)
        {
            await _CargoCompanyDal.InsertAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _CargoCompanyDal.DeleteAsync(id);
        }

        public async Task<List<CargoCompany>> TGetAllAsync()
        {
            return await _CargoCompanyDal.GetAllAsync();
        }

        public async Task<CargoCompany> TGetByIdAsync(int id)
        {
            return await _CargoCompanyDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(CargoCompany entity)
        {
            await _CargoCompanyDal.UpdateAsync(entity);
        }
    }
}
