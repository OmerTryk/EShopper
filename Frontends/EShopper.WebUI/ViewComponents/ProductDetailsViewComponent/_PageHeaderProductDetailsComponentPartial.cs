using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ProductDetailsViewComponent
{
    public class _PageHeaderProductDetailsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
