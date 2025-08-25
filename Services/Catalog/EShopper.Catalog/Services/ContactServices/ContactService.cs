using AutoMapper;
using E_Shopper.Catalog.Dtos.ContactDtos;
using E_Shopper.Catalog.Entities;
using E_Shopper.Catalog.Settings;
using MongoDB.Driver;

namespace E_Shopper.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Entities.Contact> _mongoCollection;
        private readonly IMapper _mapper;

        public ContactService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mongoCollection = database.GetCollection<Entities.Contact>(databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            try
            {
                var value = _mapper.Map<Entities.Contact>(createContactDto);
                await _mongoCollection.InsertOneAsync(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteContactAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentException("Id boş olamaz.", nameof(id));

                var result = await _mongoCollection.DeleteOneAsync(c => c.ContactId == id);
                if (result.DeletedCount == 0)
                    throw new Exception("Belirtilen ID ile eşleşen ürün bulunamadı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            try
            {
                var categories = _mapper.Map<List<ResultContactDto
                    >>(await _mongoCollection.Find(FilterDefinition<Entities.Contact>.Empty).ToListAsync());
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

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentException("Id boş olamaz.", nameof(id));

                var Contact = _mapper.Map<GetByIdContactDto>(await _mongoCollection.Find<Entities.Contact>(x => x.ContactId == id).FirstOrDefaultAsync());
                return Contact;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata {ex.Message}");
                throw;
            }
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            try
            {
                var values = _mapper.Map<Entities.Contact>(updateContactDto);
                var result = await _mongoCollection.FindOneAndReplaceAsync(x => x.ContactId == updateContactDto.ContactId, values);
                if (result == null)
                    throw new Exception($"Id'si {updateContactDto.ContactId} olan ürün bulunamadı ve güncellenemedi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata {ex.Message}");
                throw;
            }
        }
    }
}
