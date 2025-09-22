using EShopper.DtoLayer.OrderDtos.OrderAddressDtos;
using Microsoft.AspNetCore.Http.Metadata;

namespace EShopper.WebUI.Services.OrderService.OrderAddressService
{
    public interface IOrderAddressService
    {
        public Task CreateOrderAddress(CreateOrderAddressDto createOrderAddressDto);
    }
}
