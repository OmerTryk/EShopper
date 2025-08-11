using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ProductDetailsViewComponent
{
    public class _ProductCarouselProductDetailsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
