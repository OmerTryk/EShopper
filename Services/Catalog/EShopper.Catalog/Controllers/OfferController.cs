using E_Shopper.Catalog.Dtos.OfferDtos;
using E_Shopper.Catalog.Services.OfferServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shopper.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _OfferService;

        public OfferController(IOfferService OfferService)
        {
            _OfferService = OfferService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOffers()
        {
            var values = await _OfferService.GetAllOfferAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOfferById(string id)
        {
            var values = await _OfferService.GetByIdOfferAsync(id);
            if (values == null)
            {
                return NotFound();
            }
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOffer(CreateOfferDto createOfferDto)
        {
            if (createOfferDto == null)
            {
                return BadRequest("Veri boş gelemez");
            }
            await _OfferService.CreateOfferAsync(createOfferDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            if (updateOfferDto == null)
            {
                return BadRequest("Veri boş gelemez");
            }
            await _OfferService.UpdateOfferAsync(updateOfferDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id boş gelemez");
            }
            await _OfferService.DeleteOfferAsync(id);
            return Ok();
        }
    }
}
