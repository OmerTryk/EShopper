using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.DefaultViewComponent
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
