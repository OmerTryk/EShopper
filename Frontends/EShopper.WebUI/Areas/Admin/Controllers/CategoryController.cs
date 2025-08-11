using System.Text;
using EShopper.DtoLayer.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShopper.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7020/api/Category");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7020/api/Category", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View(createCategoryDto);
        }
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7020/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsondata);
                return View(values);
            }
            return View();
        }
        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");   
            var response = await client.PutAsync($"https://localhost:7020/api/Category", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }
    }
}