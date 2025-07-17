using EShopper.Discount.Dtos;

namespace EShopper.Discount.Services
{
    public interface IDiscountService
    {
        Task<IEnumerable<ResultCouponDto>> GetAllCouponAsync();
        Task<bool> DeleteCouponAsync(int id);
        Task<bool> CreateCouponAsync(CreateCouponDto createCouponDto);
        Task<bool> UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<GetByIdCouponDto> GetByIdCouponAsync(int id);
    }
}
