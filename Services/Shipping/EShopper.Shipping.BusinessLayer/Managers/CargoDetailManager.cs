using EShopper.Shipping.BusinessLayer.Abstract;
using EShopper.Shipping.DataAccessLayer.Abstract;
using EShopper.Shipping.EntityLayer.Domain;

namespace EShopper.Shipping.BusinessLayer.Managers
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetailDal;

        public CargoDetailManager(ICargoDetailDal cargoDetailDal)
        {
            _cargoDetailDal = cargoDetailDal;
        }

        public async Task TAddAsync(CargoDetail entity)
        {
            await _cargoDetailDal.InsertAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _cargoDetailDal.DeleteAsync(id);
        }

        public async Task<List<CargoDetail>> TGetAllAsync()
        {
            return await _cargoDetailDal.GetAllAsync();
        }

        public async Task<CargoDetail> TGetByIdAsync(int id)
        {
            return await _cargoDetailDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(CargoDetail entity)
        {
            await _cargoDetailDal.UpdateAsync(entity);
        }
    }
}
