using EShopper.DtoLayer.CatalogDtos.VendorBrandDtos;
using Newtonsoft.Json;

namespace EShopper.WebUI.Services.CatalogService.VendorBrandServices
{
    public class VendorBrandService : IVendorBrandService
    {
        private readonly HttpClient _httpClient;

        public VendorBrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateVendorBrandAsync(CreateVendorBrandDto createVendorBrandDto)
        {
            await _httpClient.PostAsJsonAsync("vendorbrand", createVendorBrandDto);
        }

        public async Task DeleteVendorBrandAsync(string id)
        {
            await _httpClient.DeleteAsync($"vendorbrand?id={id}");
        }
        public async Task<GetByIdVendorBrandDto> GetByIdVendorBrandAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"vendorbrand/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdVendorBrandDto>();
            return values;
        }
        public async Task<List<ResultVendorBrandDto>> GetAllVendorBrandAsync()
        {
            var responseMessage = await _httpClient.GetAsync("vendorbrand");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultVendorBrandDto>>(jsonData);
            return values;
        }
        public async Task UpdateVendorBrandAsync(UpdateVendorBrandDto updateVendorBrandDto)
        {
            await _httpClient.PutAsJsonAsync("vendorbrand", updateVendorBrandDto);
        }
    }
}
