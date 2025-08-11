using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ProductDetailsViewComponent
{
    public class _ProductInformationProductDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}