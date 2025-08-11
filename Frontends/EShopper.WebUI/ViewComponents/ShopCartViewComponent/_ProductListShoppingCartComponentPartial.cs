using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ShopCartViewComponent
{
    public class _ProductListShoppingCartComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}