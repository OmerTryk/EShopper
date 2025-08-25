using EShopper.DtoLayer.CatalogDtos.VendorBrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShopper.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class VendorBrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VendorBrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/VendorBrand");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultVendorBrandDto>>(content);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateVendorBrand")]
        public IActionResult CreateVendorBrand()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateVendorBrand")]
        public async Task<IActionResult> CreateVendorBrand(CreateVendorBrandDto createVendorBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createVendorBrandDto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/VendorBrand", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "VendorBrand", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteVendorBrand/{id}")]
        public async Task<IActionResult> DeleteVendorBrand(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/VendorBrand/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "VendorBrand", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateVendorBrand/{id}")]
        public async Task<IActionResult> UpdateVendorBrand(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/VendorBrand/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateVendorBrandDto>(content);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateVendorBrand/{id}")]
        public async Task<IActionResult> UpdateVendorBrand(UpdateVendorBrandDto updateVendorBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateVendorBrandDto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7020/api/VendorBrand", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "VendorBrand", new { area = "Admin" });
            }
            return View();
        }
    }
}
