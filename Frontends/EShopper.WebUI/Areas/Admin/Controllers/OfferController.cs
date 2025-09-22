using EShopper.DtoLayer.CatalogDtos.OfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShopper.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class OfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OfferController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Offer");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOfferDto>>(content);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateOffer")]
        public IActionResult CreateOffer()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateOffer")]
        public async Task<IActionResult> CreateOffer(CreateOfferDto createOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createOfferDto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Offer", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Offer", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteOffer/{id}")]
        public async Task<IActionResult> DeleteOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/Offer/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Offer", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateOffer/{id}")]
        public async Task<IActionResult> UpdateOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/Offer/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateOfferDto>(content);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateOffer/{id}")]
        public async Task<IActionResult> UpdateOffer(UpdateOfferDto updateOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateOfferDto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7020/api/Offer", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Offer", new { area = "Admin" });
            }
            return View();
        }
    }
}
