using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ProductListViewComponent
{
    public class _PaginationProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
