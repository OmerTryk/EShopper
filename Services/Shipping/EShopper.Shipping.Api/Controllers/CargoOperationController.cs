using AutoMapper;
using EShopper.Shipping.BusinessLayer.Abstract;
using EShopper.Shipping.DtoLayer.Dtos.CargoOperationDtos;
using EShopper.Shipping.EntityLayer.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Shipping.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _CargoOperationService;
        private readonly IMapper _mapper;

        public CargoOperationController(ICargoOperationService CargoOperationService, IMapper mapper)
        {
            _CargoOperationService = CargoOperationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoOperationList()
        {
            var values = await _CargoOperationService.TGetAllAsync();
            if (values == null) return NotFound();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDto dto)
        {
            var values = _mapper.Map<CreateCargoOperationDto, CargoOperation>(dto);
            await _CargoOperationService.TAddAsync(values);
            return Ok("Başarıyla kargo operasyonları oluşturuldu");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoOperation(int id)
        {
            await _CargoOperationService.TDeleteAsync(id);
            return Ok("Başarıyla kargo operasyonları silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoOperationById(int id)
        {
            var values = await _CargoOperationService.TGetByIdAsync(id);
            if (values == null) return NotFound();
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            var values = _mapper.Map<UpdateCargoOperationDto, CargoOperation>(dto);
            await _CargoOperationService.TUpdateAsync(values);
            return Ok("Kargo operasyonları güncelleme işlemi başarılı");
        }
    }
}
