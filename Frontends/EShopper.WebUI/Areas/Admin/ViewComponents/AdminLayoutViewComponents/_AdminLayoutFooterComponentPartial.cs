using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
