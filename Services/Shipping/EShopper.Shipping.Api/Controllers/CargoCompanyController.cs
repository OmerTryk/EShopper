using AutoMapper;
using EShopper.Shipping.BusinessLayer.Abstract;
using EShopper.Shipping.DtoLayer.Dtos.CargoCompanyDtos;
using EShopper.Shipping.EntityLayer.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Shipping.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IMapper _mapper;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService, IMapper mapper)
        {
            _cargoCompanyService = cargoCompanyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.TGetAllAsync();
            if (values == null) return NotFound();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto dto)
        {
            var values = _mapper.Map<CreateCargoCompanyDto, CargoCompany>(dto);
            await _cargoCompanyService.TAddAsync(values);
            return Ok("Başarıyla kargo şirketi oluşturuldu");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.TDeleteAsync(id);
            return Ok("Başarıyla kargo şirketi silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCompanyById(int id)
        {
            var values = await _cargoCompanyService.TGetByIdAsync(id);
            if (values == null) return NotFound();
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto dto)
        {
            var values = _mapper.Map<UpdateCargoCompanyDto,CargoCompany>(dto);
            await _cargoCompanyService.TUpdateAsync(values);
            return Ok("Kargo şirketi güncelleme işlemi başarılı");
        }
    }
}
