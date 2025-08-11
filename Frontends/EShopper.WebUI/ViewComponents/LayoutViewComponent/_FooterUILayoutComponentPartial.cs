using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.LayoutViewComponent
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
