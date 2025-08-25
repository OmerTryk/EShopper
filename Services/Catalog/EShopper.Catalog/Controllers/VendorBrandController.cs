using E_Shopper.Catalog.Dtos.VendorBrandDtos;
using E_Shopper.Catalog.Services.VendorBrandServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Shopper.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorBrandController : ControllerBase
    {
        private readonly IVendorBrandService _VendorBrandService;

        public VendorBrandController(IVendorBrandService VendorBrandService)
        {
            _VendorBrandService = VendorBrandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVendorBrands()
        {
            var values = await _VendorBrandService.GetAllVendorBrandAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendorBrandById(string id)
        {
            var values = await _VendorBrandService.GetByIdVendorBrandAsync(id);
            if (values == null)
            {
                return NotFound();
            }
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateVendorBrand(CreateVendorBrandDto createVendorBrandDto)
        {
            if (createVendorBrandDto == null)
            {
                return BadRequest("Veri boş gelemez");
            }
            await _VendorBrandService.CreateVendorBrandAsync(createVendorBrandDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateVendorBrand(UpdateVendorBrandDto updateVendorBrandDto)
        {
            if (updateVendorBrandDto == null)
            {
                return BadRequest("Veri boş gelemez");
            }
            await _VendorBrandService.UpdateVendorBrandAsync(updateVendorBrandDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendorBrand(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id boş gelemez");
            }
            await _VendorBrandService.DeleteVendorBrandAsync(id);
            return Ok();
        }
    }
}
