using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.LayoutViewComponent
{
    public class _TopbarUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}