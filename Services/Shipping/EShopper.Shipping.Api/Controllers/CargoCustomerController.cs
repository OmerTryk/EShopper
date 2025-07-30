using AutoMapper;
using EShopper.Shipping.BusinessLayer.Abstract;
using EShopper.Shipping.DtoLayer.Dtos.CargoCustomerDtos;
using EShopper.Shipping.EntityLayer.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Shipping.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly IMapper _mapper;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService, IMapper mapper)
        {
            _cargoCustomerService = cargoCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCargoCustomer()
        {
            var values = await _cargoCustomerService.TGetAllAsync();
            if (values == null) return NotFound();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDto dto)
        {
            var values = _mapper.Map<CreateCargoCustomerDto, CargoCustomer>(dto);
            await _cargoCustomerService.TAddAsync(values);
            return Ok("Kargo müşteri ekleme işlemi başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCargoCustomer(int id)
        {
            var values = await _cargoCustomerService.TGetByIdAsync(id);
            if (values == null) return NotFound();
            return Ok(values);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDto dto)
        {
            var values = _mapper.Map<UpdateCargoCustomerDto, CargoCustomer>(dto);
            await _cargoCustomerService.TUpdateAsync(values);
            return Ok("Kargo müşteri güncelleme işlemi başarılı");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCustomer(int id)
        {
            await _cargoCustomerService.TDeleteAsync(id);
            return Ok("Kargo müşteri silme işlemi başarılı");
        }
    }
}
