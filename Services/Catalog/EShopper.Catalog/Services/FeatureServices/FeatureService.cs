using System.Runtime.InteropServices;
using AutoMapper;
using E_Shopper.Catalog.Dtos.FeatureDtos;
using E_Shopper.Catalog.Entities;
using E_Shopper.Catalog.Settings;
using MongoDB.Driver;

namespace E_Shopper.Catalog.Services.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<Feature> _featuremongoCollection;
        private readonly IMapper _mapper;

        public FeatureService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featuremongoCollection = database.GetCollection<Feature>(databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            try
            {
                var values = _mapper.Map<Feature>(createFeatureDto);
                await _featuremongoCollection.InsertOneAsync(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteFeatureAsync(string id)
        {
            try
            {
                var result = await _featuremongoCollection.DeleteOneAsync(x => x.FeatureId == id);
                if (result.DeletedCount == 0)
                    throw new Exception("Belirtilen ID ile eşleşen ürün bulunamadı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            try
            {
                var values = await _featuremongoCollection.Find(FilterDefinition<Feature>.Empty).ToListAsync();
                if (values == null || values.Count == 0)
                    throw new Exception("Hiçbir öne çıkan veri bulunamadı.");
                return _mapper.Map<List<ResultFeatureDto>>(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            try
            {
                var value = await _featuremongoCollection.Find(x => x.FeatureId == id)
                       .FirstOrDefaultAsync();
                if (value == null)
                {
                    throw new Exception("Belirtilen ID ile eşleşen öne çıkan veri bulunamadı.");
                }
                return _mapper.Map<GetByIdFeatureDto>(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            try
            {
                var value = _mapper.Map<Feature>(updateFeatureDto);
                await _featuremongoCollection.ReplaceOneAsync(
                    x => x.FeatureId == updateFeatureDto.FeatureId, value);
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