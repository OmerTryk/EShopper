using System.Reflection;
using EShopper.DtoLayer.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EShopper.WebUI.ViewComponents.ProductDetailsViewComponent
{
    public class _ProductFeatureProductDetailComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductFeatureProductDetailComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7020/api/Product/{id}");
            if(response.IsSuccessStatusCode)
            { 
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ResultProductFeaturePageDto>(content);
                return View(data);
            }
            return View();
        }
    }
}
