using E_Shopper.Catalog.Dtos.ProductDetailDtos;
using E_Shopper.Catalog.Dtos.ProductDtos;

namespace E_Shopper.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<List<ResultProductWithCategoryDto>> GetProductWithCategory(string id);
    }
}
