using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.LayoutViewComponent
{
    public class _HeadUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}