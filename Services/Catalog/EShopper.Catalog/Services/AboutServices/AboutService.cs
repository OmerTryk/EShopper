using AutoMapper;
using E_Shopper.Catalog.Dtos.AboutDtos;
using E_Shopper.Catalog.Entities;
using E_Shopper.Catalog.Settings;
using MongoDB.Driver;

namespace E_Shopper.Catalog.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _AboutmongoCollection;
        private readonly IMapper _mapper;

        public AboutService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _AboutmongoCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            try
            {
                var values = _mapper.Map<About>(createAboutDto);
                await _AboutmongoCollection.InsertOneAsync(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteAboutAsync(string id)
        {
            try
            {
                var result = await _AboutmongoCollection.DeleteOneAsync(x => x.AboutId == id);
                if (result.DeletedCount == 0)
                    throw new Exception("Belirtilen ID ile eşleşen ürün bulunamadı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            try
            {
                var values = await _AboutmongoCollection.Find(FilterDefinition<About>.Empty).ToListAsync();
                if (values == null || values.Count == 0)
                    throw new Exception("Hiçbir öne çıkan veri bulunamadı.");
                return _mapper.Map<List<ResultAboutDto>>(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIdAboutDto> GetByIdAboutAsync(string id)
        {
            try
            {
                var value = await _AboutmongoCollection.Find(x => x.AboutId == id)
                       .FirstOrDefaultAsync();
                if (value == null)
                {
                    throw new Exception("Belirtilen ID ile eşleşen öne çıkan veri bulunamadı.");
                }
                return _mapper.Map<GetByIdAboutDto>(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            try
            {
                var value = _mapper.Map<About>(updateAboutDto);
                await _AboutmongoCollection.ReplaceOneAsync(
                    x => x.AboutId == updateAboutDto.AboutId, value);
                if (value == null)
                {
                    throw new Exception("Güncellenecek öne çıkan veri bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }
    }
}
