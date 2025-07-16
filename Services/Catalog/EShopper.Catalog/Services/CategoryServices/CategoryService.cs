using AutoMapper;
using E_Shopper.Catalog.Dtos.CatagoryDtos;
using E_Shopper.Catalog.Dtos.CategoryDtos;
using E_Shopper.Catalog.Dtos.ProductDetailDtos;
using E_Shopper.Catalog.Settings;
using EShopper.Catalog.Entities;
using MongoDB.Driver;

namespace E_Shopper.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _mongoCollection;
        private readonly IMapper _mapper;

        public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mongoCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            try
            {
                if (createCategoryDto == null)
                    throw new ArgumentNullException(nameof(createCategoryDto), "Kategori verisi boş olamaz.");
                if (string.IsNullOrWhiteSpace(createCategoryDto.CategoryName))
                    throw new ArgumentException("Kategori adı boş bırakılamaz.");

                var value = _mapper.Map<Category>(createCategoryDto);
                await _mongoCollection.InsertOneAsync(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteCategoryAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentException("Id boş olamaz.", nameof(id));

                var result = await _mongoCollection.DeleteOneAsync(c => c.CategoryId == id);
                if (result.DeletedCount == 0)
                    throw new Exception("Belirtilen ID ile eşleşen ürün bulunamadı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            try
            {
                var categories = _mapper.Map<List<ResultCategoryDto
                    >>(await _mongoCollection.Find(FilterDefinition<Category>.Empty).ToListAsync());
                if (!categories.Any())
                    throw new Exception("Kategori listesi bulunamadı.");

                return categories;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentException("Id boş olamaz.", nameof(id));

                var category = _mapper.Map<GetByIdCategoryDto>(await _mongoCollection.Find<Category>(x => x.CategoryId == id).FirstOrDefaultAsync());
                return category;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata {ex.Message}");
                throw;
            }
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            try
            {
                if (updateCategoryDto == null)
                    throw new ArgumentNullException(nameof(updateCategoryDto), "Kategori verisi boş olamaz.");
                if (string.IsNullOrWhiteSpace(updateCategoryDto.CategoryName))
                    throw new ArgumentException(nameof(updateCategoryDto), "Kategori adı boş bırakılamaz.");
                var values = _mapper.Map<Category>(updateCategoryDto);
                var result = await _mongoCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values);
                if (result == null)
                    throw new Exception($"Id'si {updateCategoryDto.CategoryId} olan ürün bulunamadı ve güncellenemedi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata {ex.Message}");
                throw;
            }
        }
    }
}
