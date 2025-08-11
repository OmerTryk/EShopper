using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ProductDetailsViewComponent
{
    public class _ProductFeatureProductDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
