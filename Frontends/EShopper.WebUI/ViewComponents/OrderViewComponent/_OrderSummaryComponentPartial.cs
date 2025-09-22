using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.OrderViewComponent
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
