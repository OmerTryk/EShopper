using EShopper.DtoLayer.CatalogDtos.VendorBrandDtos;

namespace EShopper.WebUI.Services.CatalogService.VendorBrandServices
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
