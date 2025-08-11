using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.LayoutViewComponent
{
    public class _PageHeaderUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
