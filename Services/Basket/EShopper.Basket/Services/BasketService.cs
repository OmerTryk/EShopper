using System.Text.Json;
using EShopper.Basket.Dtos;
using EShopper.Basket.Settings;

namespace EShopper.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<bool> DeleteBasketAsync(string userId)
        {
            var status = await _redisService.GetDatabase().KeyDeleteAsync(userId);
            if (!status) throw new Exception("Sepet silinemedi");
            return status;
        }

        public async Task<BasketTotalDto> GetBasketTotalAsync(string userId)
        {
            var values = await _redisService.GetDatabase().StringGetAsync(userId);
            if (values.IsNullOrEmpty) throw new Exception("Sepet bulunamadı");
            try
            {
                return JsonSerializer.Deserialize<BasketTotalDto>(values);
            }
            catch (JsonException ex)
            {
                throw new Exception("Redis'teki sepet verisi bozuk!", ex);
            }
        }


        public async Task<bool> SaveBasketAsync(BasketTotalDto basket)
        {
            var status = _redisService.GetDatabase().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
            if (!status.IsCompletedSuccessfully || !status.Result)
            {
                throw new Exception("Sepet kaydedilemedi");
            }
            return status.Result;
        }
    }
}
