using EShopper.DtoLayer.CatalogDtos.ContactDtos;
using EShopper.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShopper.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createContactDto);
            }
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createContactDto);
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Contact", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                ModelState.AddModelError("", "Yorum Eklenirken Bir Hata Oluştu");
                return View(createContactDto);
            }
        }
    }
}
