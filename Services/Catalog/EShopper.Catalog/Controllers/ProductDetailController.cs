using E_Shopper.Catalog.Dtos.ProductDetailDtos;
using E_Shopper.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shopper.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            if (values == null || !values.Any()) return NotFound("Hiç bir veri bulunamadı");
            return Ok(values);
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("ID boş olamaz.");
            var values = await _productDetailService.GetByIdProductDetailAsync(id);
            if (values == null) return NotFound($"ID '{id}' ile eşleşen kategori bulunamadı.");
            return Ok(values);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("ID boş olamaz.");
            await _productDetailService.DeleteProductDetailAsync(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Kayıt başarıyla tamamlandı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Kategori başarıyla güncellendi");
        }
    }
}
