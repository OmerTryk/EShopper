using System.Text;
using EShopper.DtoLayer.IdentityDtos.RegisterDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShopper.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
            
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterDto userRegisterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(userRegisterDto);
            var content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:5001/api/Register", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("", "Registration failed. Please try again.");
                return View(userRegisterDto);
            }
        }
    }
}
