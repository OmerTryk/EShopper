using EShopper.DtoLayer.CatalogDtos.ProductDetailsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShopper.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/ProductDetail/getproductdetailbyproductid/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ResultProductDetailByProductId>(content);
                return View(data);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateProductDetail")]
        public IActionResult CreateProductDetail()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateProductDetail")]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createProductDetailDto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/ProductDetail", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteProductDetail/{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/ProductDetail/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/ProductDetail/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(content);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateProductDetail/{id}")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateProductDetailDto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7020/api/ProductDetail", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
            }
            return View();
        }
    }
}
