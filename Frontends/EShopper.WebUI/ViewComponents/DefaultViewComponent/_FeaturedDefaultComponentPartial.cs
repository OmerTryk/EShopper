using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.DefaultViewComponent
{
    public class _FeaturedDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}