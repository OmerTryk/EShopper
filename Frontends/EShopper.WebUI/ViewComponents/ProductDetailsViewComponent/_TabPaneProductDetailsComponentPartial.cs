using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ProductDetailsViewComponent
{
    public class _TabPaneProductDetailsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
