using AutoMapper;
using E_Shopper.Catalog.Dtos.OfferDtos;
using E_Shopper.Catalog.Entities;
using E_Shopper.Catalog.Settings;
using MongoDB.Driver;

namespace E_Shopper.Catalog.Services.OfferServices
{
    public class OfferService : IOfferService
    {
        private readonly IMongoCollection<Offer> _offermongoCollection;
        private readonly IMapper _mapper;

        public OfferService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _offermongoCollection = mongoDatabase.GetCollection<Offer>(databaseSettings.OfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            try
            {
                var values = _mapper.Map<Offer>(createOfferDto);
                await _offermongoCollection.InsertOneAsync(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteOfferAsync(string id)
        {
            try
            {
                var result = await _offermongoCollection.DeleteOneAsync(x => x.OfferId == id);
                if (result.DeletedCount == 0)
                {
                    throw new Exception("Silinecek teklif bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResultOfferDto>> GetAllOfferAsync()
        {
            try
            {
                var values = await _offermongoCollection.Find(FilterDefinition<Offer>.Empty).ToListAsync();
                return _mapper.Map<List<ResultOfferDto>>(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIdOfferDto> GetByIdOfferAsync(string id)
        {
            try
            {
                var value = await _offermongoCollection.Find(x => x.OfferId == id).FirstOrDefaultAsync();
                if (value == null)
                {
                    throw new Exception("Teklif bulunamadı.");
                }
                return _mapper.Map<GetByIdOfferDto>(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateOfferAsync(UpdateOfferDto updateOfferDto)
        {
            try
            {
                var value = _mapper.Map<Offer>(updateOfferDto);
                await _offermongoCollection.ReplaceOneAsync(x => x.OfferId == updateOfferDto.OfferId, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }
    }
}
