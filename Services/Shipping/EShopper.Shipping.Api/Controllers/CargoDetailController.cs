using AutoMapper;
using EShopper.Shipping.BusinessLayer.Abstract;
using EShopper.Shipping.DtoLayer.Dtos.CargoDetailDtos;
using EShopper.Shipping.EntityLayer.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Shipping.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailService;
        private readonly IMapper _mapper;

        public CargoDetailController(ICargoDetailService CargoDetailService, IMapper mapper)
        {
            _CargoDetailService = CargoDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoDetailList()
        {
            var values = await _CargoDetailService.TGetAllAsync();
            if (values == null) return NotFound();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDto dto)
        {
            var values = _mapper.Map<CreateCargoDetailDto, CargoDetail>(dto);
            await _CargoDetailService.TAddAsync(values);
            return Ok("Başarıyla kargo şirket detayları oluşturuldu");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            await _CargoDetailService.TDeleteAsync(id);
            return Ok("Başarıyla kargo şirket detayları silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoDetailById(int id)
        {
            var values = await _CargoDetailService.TGetByIdAsync(id);
            if (values == null) return NotFound();
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDto dto)
        {
            var values = _mapper.Map<UpdateCargoDetailDto, CargoDetail>(dto);
            await _CargoDetailService.TUpdateAsync(values);
            return Ok("Kargo şirket detayları güncelleme işlemi başarılı");
        }
    }
}
