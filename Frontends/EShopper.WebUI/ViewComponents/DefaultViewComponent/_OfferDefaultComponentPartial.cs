using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.DefaultViewComponent
{
    public class _OfferDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
