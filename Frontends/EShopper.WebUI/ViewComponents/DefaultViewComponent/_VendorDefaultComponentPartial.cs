using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.DefaultViewComponent
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}