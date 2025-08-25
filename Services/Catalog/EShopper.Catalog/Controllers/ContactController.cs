using E_Shopper.Catalog.Dtos.ContactDtos;
using E_Shopper.Catalog.Services.ContactServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Shopper.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IContactService _ContactService;

        public ContactController(IContactService ContactService)
        {
            _ContactService = ContactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var Contacts = await _ContactService.GetAllContactAsync();
            return Ok(Contacts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var Contact = await _ContactService.GetByIdContactAsync(id);
            if (Contact == null)
            {
                return NotFound();
            }
            return Ok(Contact);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            if (createContactDto == null)
            {
                return BadRequest("Veri boş gelemez");
            }
            await _ContactService.CreateContactAsync(createContactDto);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            if (updateContactDto == null)
            {
                return BadRequest("Veri boş gelemez");
            }
            await _ContactService.UpdateContactAsync(updateContactDto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id boş gelemez");
            }
            await _ContactService.DeleteContactAsync(id);
            return Ok();
        }
    }
}
