using EShopper.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace EShopper.WebUI.Services.CatalogService.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync("product", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync($"product?id={id}");
        }
        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"product/{id}");
            var values = await responseMessage.Content.ReadFromJsonAsync<GetByIdProductDto>();
            return values;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("product");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return values;
        }
        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync("product", updateProductDto);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategory(string id)
        {
            var response = await _httpClient.GetAsync($"product/productwithcategory/{id}");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }
    }
}
