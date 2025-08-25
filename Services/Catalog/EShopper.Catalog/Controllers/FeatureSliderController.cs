using E_Shopper.Catalog.Dtos.FeatureSliderDtos;
using E_Shopper.Catalog.Services.FeaturesSliderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Shopper.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSliderController : Controller
    {
        private readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFeatureSlider()
        {
            var featureSliders = await _featureSliderService.GetAllFeatureSliderAsync();
            return Ok(featureSliders);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Kayıt başarılı");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Güncelleme başarılı");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Silme işlemi başarılı");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFeatureSlider(string id)
        {
            var featureSlider = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            if (featureSlider == null)
            {
                return NotFound("Özellik kaydı bulunamadı");
            }
            return Ok(featureSlider);
        }
    }
}
