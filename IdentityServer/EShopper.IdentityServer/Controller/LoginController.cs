using System.Threading.Tasks;
using EShopper.IdentityServer.Dtos;
using EShopper.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.IdentityServer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(userLoginDto.UserName,userLoginDto.Password,false,false);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Kullacını Adı veya Şifre Yanlış");
            }
        }
    }
}
