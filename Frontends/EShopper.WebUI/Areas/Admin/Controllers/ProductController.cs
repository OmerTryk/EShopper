using EShopper.DtoLayer.CatalogDtos.CategoryDtos;
using EShopper.DtoLayer.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EShopper.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Product");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(content);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Category");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(content);
                List<SelectListItem> categoryItem = (from x in categories
                                                     select new SelectListItem
                                                     {
                                                         Text = x.CategoryName,
                                                         Value = x.CategoryId
                                                     }).ToList();
                ViewBag.Categories = categoryItem;
            }
            return View();
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createProductDto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Product", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseCategory = await client.GetAsync("https://localhost:7020/api/Category");
            if (responseCategory.IsSuccessStatusCode)
            {
                var content = await responseCategory.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(content);
                List<SelectListItem> categoryItem = (from x in categories
                                                     select new SelectListItem
                                                     {
                                                         Text = x.CategoryName,
                                                         Value = x.CategoryId
                                                     }).ToList();
                ViewBag.Categories = categoryItem;
            }
            var response = await client.GetAsync($"https://localhost:7020/api/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(content);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateProductDto);
            var content = new StringContent(jsondata, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7020/api/Product", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
