using EShopper.DtoLayer.CatalogDtos.OfferDtos;
using Newtonsoft.Json;

namespace EShopper.WebUI.Services.CatalogService.OfferServices
{
    public class OfferService : IOfferService
    {
        private readonly HttpClient _httpClient;

        public OfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOfferAsync(CreateOfferDto createOfferDto)
        {
            await _httpClient.PostAsJsonAsync("offer", createOfferDto);
        }

        public async Task DeleteOfferAsync(string id)
        {
            await _httpClient.DeleteAsync($"offer?id={id}");
        }
        public async Task<GetByIdOfferDto> GetByIdOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"offer/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdOfferDto>();
            return values;
        }
        public async Task<List<ResultOfferDto>> GetAllOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("offer");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOfferDto>>(jsonData);
            return values;
        }
        public async Task UpdateOfferAsync(UpdateOfferDto updateOfferDto)
        {
            await _httpClient.PutAsJsonAsync("offer", updateOfferDto);
        }
    }
}
