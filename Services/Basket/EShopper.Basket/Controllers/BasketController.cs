using EShopper.Basket.Dtos;
using EShopper.Basket.LoggingService;
using EShopper.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Basket.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            var user = User.Claims;
            var values = await _basketService.GetBasketTotalAsync(_loginService.GetUserId);
            if (values == null)
            {
                return NotFound();
            }
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> SaveBasket(BasketTotalDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Sepet boş");
            }
            dto.UserId = _loginService.GetUserId;
            var result = await _basketService.SaveBasketAsync(dto);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sepet kaydedilirken bir hata oluştu.");
            }
            return Ok("Sepet başarıyla kaydedildi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            var result = await _basketService.DeleteBasketAsync(_loginService.GetUserId);
            if (!result)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Sepet silinirken bir hata oluştu.");
            }
            return Ok("Sepet başarıyla silindi");
        }
    }
}
