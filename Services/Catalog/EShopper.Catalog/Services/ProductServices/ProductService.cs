using AutoMapper;
using E_Shopper.Catalog.Dtos.CategoryDtos;
using E_Shopper.Catalog.Dtos.ProductDetailDtos;
using E_Shopper.Catalog.Dtos.ProductDtos;
using E_Shopper.Catalog.Settings;
using EShopper.Catalog.Entities;
using MongoDB.Driver;

namespace E_Shopper.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productmongoCollection;
        private readonly IMongoCollection<Category> _categorymongoCollection;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productmongoCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categorymongoCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            try
            {
                if (createProductDto == null) throw new ArgumentNullException(nameof(createProductDto), "Ürün verileri boş gönderilemez.");

                if (string.IsNullOrWhiteSpace(createProductDto.ProductName)) throw new ArgumentException(nameof(createProductDto), "Ürün ismi boş gönderilemez.");

                if (createProductDto.ProductPrice <= 0)
                    throw new ArgumentException("Ürün fiyatı sıfırdan büyük olmalıdır.");

                await _productmongoCollection.InsertOneAsync(_mapper.Map<Product>(createProductDto));

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CreateProductAsync] Hata {ex.Message}");
                throw;
            }
        }

        public async Task DeleteProductAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentException("Id boş olamaz.", nameof(id));
                var result = await _productmongoCollection.DeleteOneAsync(p => p.ProductId == id);
                if (result.DeletedCount == 0)
                    throw new Exception("Belirtilen ID ile eşleşen ürün bulunamadı.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[DeleteProductAsync] Hata {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            try
            {
                var products = _mapper.Map<List<ResultProductDto>>(await _productmongoCollection.Find(FilterDefinition<Product>.Empty).ToListAsync());
                if (!products.Any())
                    throw new Exception("Veritabanında hiç ürün bulunamadı.");
                return products;

            }
            catch (Exception ex)
            {

                Console.WriteLine($"[GetAllProductAsync] Hata {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("Id boş olamaz.", nameof(id));
                var productEntities = await _productmongoCollection.Find(p => p.ProductId == id).FirstOrDefaultAsync();
                if (productEntities == null) throw new Exception($"{id} değerinde bir ürün bulunamadı");
                return _mapper.Map<GetByIdProductDto>(productEntities);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetByIdProductAsync] Hata {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategory(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentException("Id boş olamaz.", nameof(id));
                var values = await _productmongoCollection.Find(x => x.CategoryId == id).ToListAsync();
                if (values == null)
                    throw new Exception($"Id'si {id} olan ürün bulunamadı.");
                var result = _mapper.Map<List<ResultProductWithCategoryDto>>(values); 
                    result.ForEach(p =>
                    {
                        var category = _categorymongoCollection.Find(c => c.CategoryId == p.CategoryId).FirstOrDefault();
                        if (category != null)
                        {
                            p.CategoryName = category.CategoryName;
                        }
                    });
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[GetProductWithCategory] Hata {ex.Message}");
                throw;
            }
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            try
            {
                if (updateProductDto == null)
                    throw new ArgumentNullException(nameof(updateProductDto), "Ürün verisi boş olamaz.");

                if (string.IsNullOrWhiteSpace(updateProductDto.ProductId))
                    throw new ArgumentException("Ürün Id boş bırakılamaz.", nameof(updateProductDto.ProductId));

                if (string.IsNullOrWhiteSpace(updateProductDto.ProductName))
                    throw new ArgumentException(nameof(updateProductDto), "Ürün adı boş bırakılamaz.");

                var values = _mapper.Map<Product>(updateProductDto);
                var result = await _productmongoCollection.FindOneAndReplaceAsync(p => p.ProductId == updateProductDto.ProductId, values);

                if (result == null)
                    throw new Exception($"Id'si {updateProductDto.ProductId} olan ürün bulunamadı ve güncellenemedi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[UpdateProductAsync] Hata {ex.Message}");
                throw;
            }
        }
    }
}
