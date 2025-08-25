using System.Threading.Tasks;
using EShopper.IdentityServer.Dtos;
using EShopper.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static IdentityServer4.IdentityServerConstants;

namespace EShopper.IdentityServer.Controller
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterDto dto)
        {
            if (dto == null) return BadRequest();
            var values = new ApplicationUser
            {
                UserName = dto.Username,
                Email = dto.Email,
                Surname = dto.Surname,
                Name = dto.Name
            };
            var result = await _userManager.CreateAsync(values, dto.Password);
            if (!result.Succeeded) return BadRequest("Bir hata oluştu");
            return Ok("Kayıt başarıyla kaydedildi");
        }
    }
}
