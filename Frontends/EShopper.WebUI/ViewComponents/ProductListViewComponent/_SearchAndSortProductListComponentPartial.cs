using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ProductListViewComponent
{
    public class _SearchAndSortProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
