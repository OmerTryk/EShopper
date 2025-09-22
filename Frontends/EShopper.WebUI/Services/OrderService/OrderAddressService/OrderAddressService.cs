using EShopper.DtoLayer.OrderDtos.OrderAddressDtos;

namespace EShopper.WebUI.Services.OrderService.OrderAddressService
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly HttpClient _httpClient;
        public OrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateOrderAddress(CreateOrderAddressDto createOrderAddressDto)
        {
            await _httpClient.PostAsJsonAsync<CreateOrderAddressDto>("address", createOrderAddressDto);
        }
    }
}
