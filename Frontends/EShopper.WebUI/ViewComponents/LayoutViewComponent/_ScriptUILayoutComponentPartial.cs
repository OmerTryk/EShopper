using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.LayoutViewComponent
{
    public class _ScriptUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
