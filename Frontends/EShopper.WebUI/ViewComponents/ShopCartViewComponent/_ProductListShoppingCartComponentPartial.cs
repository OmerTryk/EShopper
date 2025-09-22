using EShopper.WebUI.Services.BasketService;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ShopCartViewComponent
{
    public class _ProductListShoppingCartComponentPartial : ViewComponent
    { 
        private readonly IBasketService _basketService;

        public _ProductListShoppingCartComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasket();
            return View(values);
        }
    }
}