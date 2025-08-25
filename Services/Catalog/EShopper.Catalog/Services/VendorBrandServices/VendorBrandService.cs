using AutoMapper;
using E_Shopper.Catalog.Dtos.VendorBrandDtos;
using E_Shopper.Catalog.Entities;
using E_Shopper.Catalog.Settings;
using MongoDB.Driver;

namespace E_Shopper.Catalog.Services.VendorBrandServices
{
    public class VendorBrandService : IVendorBrandService
    {
        private readonly IMongoCollection<VendorBrand> _VendorBrandmongoCollection;
        private readonly IMapper _mapper;

        public VendorBrandService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(databaseSettings.DatabaseName);
            _VendorBrandmongoCollection = mongoDatabase.GetCollection<VendorBrand>(databaseSettings.VendorBrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateVendorBrandAsync(CreateVendorBrandDto createVendorBrandDto)
        {
            try
            {
                var values = _mapper.Map<VendorBrand>(createVendorBrandDto);
                await _VendorBrandmongoCollection.InsertOneAsync(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteVendorBrandAsync(string id)
        {
            try
            {
                var result = await _VendorBrandmongoCollection.DeleteOneAsync(x => x.VendorBrandId == id);
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

        public async Task<List<ResultVendorBrandDto>> GetAllVendorBrandAsync()
        {
            try
            {
                var values = await _VendorBrandmongoCollection.Find(FilterDefinition<VendorBrand>.Empty).ToListAsync();
                return _mapper.Map<List<ResultVendorBrandDto>>(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIdVendorBrandDto> GetByIdVendorBrandAsync(string id)
        {
            try
            {
                var value = await _VendorBrandmongoCollection.Find(x => x.VendorBrandId == id).FirstOrDefaultAsync();
                if (value == null)
                {
                    throw new Exception("Teklif bulunamadı.");
                }
                return _mapper.Map<GetByIdVendorBrandDto>(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateVendorBrandAsync(UpdateVendorBrandDto updateVendorBrandDto)
        {
            try
            {
                var value = _mapper.Map<VendorBrand>(updateVendorBrandDto);
                await _VendorBrandmongoCollection.ReplaceOneAsync(x => x.VendorBrandId == updateVendorBrandDto.VendorBrandId, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }
    }
}
