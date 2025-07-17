using EShopper.Discount.Dtos;
using EShopper.Discount.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _service;

        public DiscountController(IDiscountService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            var values = await _service.GetAllCouponAsync();
            if (!values.Any()) return NotFound("Kupon bulunamadı.");
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CouponList(int id)
        {
            var values = await _service.GetByIdCouponAsync(id);
            if (values == null) return NotFound($"Kupon bulunamadı. CouponId: {id}");
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var values = await _service.CreateCouponAsync(createCouponDto);
            if (!values) return BadRequest("Kupon kayıt işlemi başarısız");
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var values = await _service.UpdateCouponAsync(updateCouponDto);
            if (!values) return BadRequest("Kupon güncelleme işlemi başarısız");
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            var values = await _service.DeleteCouponAsync(id);
            if (!values) return BadRequest("Kupon silme işlemi başarısız");
            return Ok("Kupon başarıyla silindi");
        }
    }
}
