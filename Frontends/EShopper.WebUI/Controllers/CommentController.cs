using EShopper.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShopper.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.Rating = 3; // Default rating value
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createCommentDto);
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7250/api/Comment", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductDetails", nameof(ProductListController));
            }
            else
            {
                ModelState.AddModelError("", "Yorum Eklenirken Bir Hata Oluştu");
                return View(createCommentDto);
            }
        }
    }
}
