using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductDetailsCardProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
