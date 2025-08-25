using E_Shopper.Catalog.Dtos.ProductDetailDtos;
using E_Shopper.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Shopper.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            if (values == null || !values.Any()) return NotFound("Hiç bir veri bulunamadı");
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("ID boş olamaz.");
            var values = await _productService.GetByIdProductAsync(id);
            if (values == null) return NotFound($"ID '{id}' ile eşleşen kategori bulunamadı.");
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("ID boş olamaz.");
            await _productService.DeleteProductAsync(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Kayıt başarıyla tamamlandı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Kategori başarıyla güncellendi");
        }

        [HttpGet("getproductwithcategory/{id}")]
        public async Task<IActionResult> GetProductWithCategory(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("ID boş olamaz.");
            var values = await _productService.GetProductWithCategory(id);
            return Ok(values);
        }
    }
}
