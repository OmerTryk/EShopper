using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.OrderViewComponent
{
    public class _OrderDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
