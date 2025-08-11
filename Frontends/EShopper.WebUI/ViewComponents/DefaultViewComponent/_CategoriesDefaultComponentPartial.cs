using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.DefaultViewComponent
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
