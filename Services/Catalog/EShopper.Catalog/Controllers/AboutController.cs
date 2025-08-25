using E_Shopper.Catalog.Dtos.AboutDtos;
using E_Shopper.Catalog.Services.AboutServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Shopper.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _AboutService;

        public AboutController(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbouts()
        {
            var Abouts = await _AboutService.GetAllAboutAsync();
            return Ok(Abouts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            var About = await _AboutService.GetByIdAboutAsync(id);
            if (About == null)
            {
                return NotFound();
            }
            return Ok(About);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            if (createAboutDto == null)
            {
                return BadRequest("Veri boş gelemez");
            }
            await _AboutService.CreateAboutAsync(createAboutDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            if (updateAboutDto == null)
            {
                return BadRequest("Veri boş gelemez");
            }
            await _AboutService.UpdateAboutAsync(updateAboutDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id boş gelemez");
            }
            await _AboutService.DeleteAboutAsync(id);
            return Ok();
        }
    }
}
