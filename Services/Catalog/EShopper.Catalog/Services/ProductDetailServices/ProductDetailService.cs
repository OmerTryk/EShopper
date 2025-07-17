using AutoMapper;
using E_Shopper.Catalog.Dtos.ProductDetailDtos;
using E_Shopper.Catalog.Settings;
using EShopper.Catalog.Entities;
using MongoDB.Driver;

namespace E_Shopper.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _mongoCollection;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mongoCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            try
            {
                if (createProductDetailDto == null) throw new ArgumentNullException("Ürün detayları boş olamaz", nameof(createProductDetailDto));

                var value = _mapper.Map<ProductDetail>(createProductDetailDto);

                if (value == null) throw new InvalidOperationException("Ürün detayları ProductDetail nesnesine dönüştürülemedi. Mapper yapılandırmasını kontrol edin.");

                await _mongoCollection.InsertOneAsync(value);


            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CreateProductDetailAsync] Hata {ex.Message}");
                throw;
            }
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Id boş olamaz.", nameof(id));

                var result = await _mongoCollection.DeleteOneAsync(pd => pd.ProductDetailId == id);

                if (result.DeletedCount == 0)
                    throw new Exception("Belirtilen ID ile eşleşen ürün bulunamadı.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DeleteProductDetailAsync] Hata {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            try
            {
                var values = await _mongoCollection.Find(FilterDefinition<ProductDetail>.Empty).ToListAsync();
                if (values == null || !values.Any()) throw new Exception("Veritabanında hiç ürün detayı bulunamadı");

                var results = _mapper.Map<List<ResultProductDetailDto>>(values);
                if (results == null) throw new InvalidOperationException("Ürün detayları ResultProductDetailDto nesnesine dönüştürülemedi. Mapper yapılandırmasını kontrol edin.");
                return results;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetAllProductDetailAsync] Hata {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Id boş olamaz", nameof(id));
                var value = await _mongoCollection.Find(pd => pd.ProductDetailId == id).FirstOrDefaultAsync();
                if (value == null)
                    throw new KeyNotFoundException($"'{id}' değerine sahip bir ürün detayı bulunamadı.");

                var result = _mapper.Map<GetByIdProductDetailDto>(value);
                if (result == null) throw new InvalidOperationException("Ürün detayları GetByIdProductDetailDto nesnesine dönüştürülemedi. Mapper yapılandırmasını kontrol edin.");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetByIdProductDetailAsync] Hata {ex.Message}");
                throw;
            }
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            try
            {
                if (updateProductDetailDto == null) throw new ArgumentNullException(nameof(updateProductDetailDto), "Ürün detay verisi boş olamaz.");

                var values = _mapper.Map<ProductDetail>(updateProductDetailDto);

                if (values == null) throw new InvalidOperationException("Ürün detayları UpdateProductDetailDto nesnesine dönüştürülemedi. Mapper yapılandırmasını kontrol edin.");

                var result = await _mongoCollection.FindOneAndReplaceAsync(pd => pd.ProductDetailId == updateProductDetailDto.ProductDetailId, values);
                if (result == null)
                    throw new Exception($"{result.ProductDetailId} ID'sine sahip ürün detayı bulunamadı. Güncelleme başarısız.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UpdateProductDetailAsync] Hata {ex.Message}");
                throw;
            }
        }
    }
}
