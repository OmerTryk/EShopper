using E_Shopper.Catalog.Dtos.CategoryDtos;
using E_Shopper.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Shopper.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Authorize(Policy = "CatalogReadAccess")]
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            if (values == null || !values.Any()) return NotFound("Hiç bir veri bulunamadı");
            return Ok(values);
        }

        [Authorize(Policy = "CatalogReadAccess")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("ID boş olamaz.");
            var values = await _categoryService.GetByIdCategoryAsync(id);
            if (values == null) return NotFound($"ID '{id}' ile eşleşen kategori bulunamadı.");
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("ID boş olamaz.");
            await _categoryService.DeleteCategoryAsync(id);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kayıt başarıyla tamamlandı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori başarıyla güncellendi");
        }
    }
}


