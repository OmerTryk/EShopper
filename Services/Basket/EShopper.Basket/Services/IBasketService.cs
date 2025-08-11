using EShopper.Basket.Dtos;

namespace EShopper.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketTotalAsync(string userId);
        Task<bool> SaveBasketAsync(BasketTotalDto basket);
        Task<bool> DeleteBasketAsync(string userId);
    } 
}
