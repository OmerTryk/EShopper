using EShopper.DtoLayer.BasketDtos;
using EShopper.WebUI.Services.BasketService;
using EShopper.WebUI.Services.CatalogService.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public ShopCartController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var values = await _productService.GetByIdProductAsync(productId);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1
            };
            await _basketService.AddBasketItem(items);
            return View(items);
        }
        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
