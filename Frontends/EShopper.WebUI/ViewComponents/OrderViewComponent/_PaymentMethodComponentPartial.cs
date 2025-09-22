using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.OrderViewComponent
{
    public class _PaymentMethodComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
