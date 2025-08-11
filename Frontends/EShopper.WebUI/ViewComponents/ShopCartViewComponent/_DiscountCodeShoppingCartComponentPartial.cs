using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ShopCartViewComponent
{
    public class _DiscountCodeShoppingCartComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
