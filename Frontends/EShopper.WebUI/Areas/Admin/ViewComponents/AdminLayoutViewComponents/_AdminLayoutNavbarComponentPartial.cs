using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
