using AutoMapper;
using E_Shopper.Catalog.Dtos.FeatureSliderDtos;
using E_Shopper.Catalog.Entities;
using E_Shopper.Catalog.Settings;
using EShopper.Catalog.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Core.Misc;

namespace E_Shopper.Catalog.Services.FeaturesSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featuremongoCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _featuremongoCollection = database.GetCollection<FeatureSlider>(databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            try
            {
                var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
                await _featuremongoCollection.InsertOneAsync(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            try
            {
                var result = await _featuremongoCollection.DeleteOneAsync(f => f.FeatureSliderId == id);
                if (result.DeletedCount == 0)
                {
                    throw new Exception("Belirtilen ID ile eşleşen özellik kaydı bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            try
            {
                var values = await _featuremongoCollection.Find(FilterDefinition<FeatureSlider>.Empty).ToListAsync();
                if (values == null || !values.Any())
                {
                    throw new Exception("Özellik kaydı bulunamadı.");
                }
                return _mapper.Map<List<ResultFeatureSliderDto>>(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            try
            {
                var featureSlider = await _featuremongoCollection.Find(f => f.FeatureSliderId == id).FirstOrDefaultAsync();
                if (featureSlider == null)
                {
                    throw new Exception("Belirtilen ID ile eşleşen özellik kaydı bulunamadı.");
                }
                return _mapper.Map<GetByIdFeatureSliderDto>(featureSlider);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            try
            {
                var values = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
                var result = await _featuremongoCollection.FindOneAndReplaceAsync(f => f.FeatureSliderId == updateFeatureSliderDto.FeatureSliderId, values);
                if (result == null)
                {
                    throw new Exception("Güncellenecek özellik kaydı bulunamadı.");
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