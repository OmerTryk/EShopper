using E_Shopper.Catalog.Dtos.VendorBrandDtos;

namespace E_Shopper.Catalog.Services.VendorBrandServices
{
    public interface IVendorBrandService
    {
        Task<List<ResultVendorBrandDto>> GetAllVendorBrandAsync();
        Task CreateVendorBrandAsync(CreateVendorBrandDto createVendorBrandDto);
        Task UpdateVendorBrandAsync(UpdateVendorBrandDto updateVendorBrandDto);
        Task DeleteVendorBrandAsync(string id);
        Task<GetByIdVendorBrandDto> GetByIdVendorBrandAsync(string id);
    }
}
