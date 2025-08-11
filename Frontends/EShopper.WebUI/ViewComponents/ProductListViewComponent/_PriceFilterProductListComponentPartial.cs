using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ProductListViewComponent
{
    public class _PriceFilterProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
