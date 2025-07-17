using Dapper;
using EShopper.Discount.Context;
using EShopper.Discount.Dtos;

namespace EShopper.Discount.Services
{
    public class DiscountService : IDiscountService
    {

        private readonly DapperContext _context;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(DapperContext context, ILogger<DiscountService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons(CouponCode,Rate,IsActive,ValidDate) values(@CouponCode, @Rate, @IsActive, @ValidDate)";
            // var parametres = new DynamicParameters();
            try
            {
                //Eğer dto içindeki parametre adları ve sql sorgusundaki parametre adları eşleşiyorsa parametre eklemeye gerek duyulmaz
                //parametres.Add("@code",createCouponDto.CouponCode);
                //parametres.Add("@rate", createCouponDto.Rate);
                //parametres.Add("@isactive", createCouponDto.IsActive);
                //parametres.Add("@validdate", createCouponDto.ValidDate);

                using var connection = _context.CreateConnection();
                var result = await connection.ExecuteAsync(query, createCouponDto);
                if (result == 0)
                {
                    _logger.LogWarning("Kupon eklenemedi. CouponCode: {Code}", createCouponDto.CouponCode);
                    throw new Exception("Kayıt işlemi başarısız");
                }
                _logger.LogInformation("Kupon başarıyla eklendi: {Code}", createCouponDto.CouponCode);
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kupon eklenirken hata oluştu. CouponCode: {Code}", createCouponDto.CouponCode);
                throw;
            }
        }

        public async Task<bool> DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons Where CouponId = @couponId";
            var parametres = new DynamicParameters();
            try
            {
                parametres.Add("@couponId", id);

                using var connection = _context.CreateConnection();
                var result = await connection.ExecuteAsync(query, parametres);
                if (result == 0)
                {
                    _logger.LogWarning("Kupon silinemedi. CouponId: {Code}", id);
                    throw new Exception("Silme işlemi başarısız");
                }

                _logger.LogInformation("Kupon başarıyla silindi: {Code}", id);
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kupon silinirken hata oluştu. CouponId: {Code}", id);
                throw;
            }

        }

        public async Task<IEnumerable<ResultCouponDto>> GetAllCouponAsync()
        {
            string query = "Select * from Coupons";
            try
            {
                using var connection = _context.CreateConnection();
                var result = await connection.QueryAsync<ResultCouponDto>(query);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kupon verileri getirilirken hata oluştu.");
                throw;
            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "Select * from Coupons Where CouponId = @couponId";
            var parametres = new DynamicParameters();
            try
            {
                parametres.Add("@couponId", id);

                using var connection = _context.CreateConnection();
                var result = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parametres);
                if (result == null)
                {
                    _logger.LogWarning("Kupon bulunamadı. CouponId: {CouponId}", id);
                    throw new Exception("Kupon bulunamadı");
                }

                _logger.LogInformation("Kupon başarıyla bulundu: {Code}", id);
                return result;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kupon getirilirken hata oluştu. CouponId: {CouponId}", id);
                throw;
            }
        }

        public async Task<bool> UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set CouponCode=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parametres = new DynamicParameters();
            try
            {
                parametres.Add("@couponId", updateCouponDto.CouponId);
                parametres.Add("@code", updateCouponDto.CouponCode);
                parametres.Add("@rate", updateCouponDto.Rate);
                parametres.Add("@isactive", updateCouponDto.IsActive);
                parametres.Add("@validdate", updateCouponDto.ValidDate);

                using var connection = _context.CreateConnection();
                var result = await connection.ExecuteAsync(query, parametres);
                if (result == 0)
                {
                    _logger.LogWarning("Güncellenecek kupon bulunamadı. CouponId: {CouponId}", updateCouponDto.CouponId);
                    throw new Exception("Kupon bulunamadı. Güncelleme başarısız.");
                }

                _logger.LogInformation("Kupon başarıyla güncellendi. CouponId: {CouponId}", updateCouponDto.CouponId);
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Kupon güncellenirken hata oluştu. CouponId: {CouponId}", updateCouponDto.CouponId);
                throw;
            }
        }
    }
}
