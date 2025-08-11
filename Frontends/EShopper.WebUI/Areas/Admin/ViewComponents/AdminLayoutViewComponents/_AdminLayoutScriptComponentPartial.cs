using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
