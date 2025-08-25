using E_Shopper.Catalog.Dtos.FeatureDtos;
using E_Shopper.Catalog.Services.FeatureServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Shopper.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeatures()
        {
            var features = await _featureService.GetAllFeatureAsync();
            return Ok(features);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            var feature = await _featureService.GetByIdFeatureAsync(id);
            if (feature == null)
            {
                return NotFound();
            }
            return Ok(feature);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            if (createFeatureDto == null)
            {
                return BadRequest("Veri boş gelemez");
            }
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            if (updateFeatureDto == null)
            {
                return BadRequest("Veri boş gelemez");
            }
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id boş gelemez");
            }
            await _featureService.DeleteFeatureAsync(id);
            return Ok();
        }
    }
}