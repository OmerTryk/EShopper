using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ColorFilterProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
